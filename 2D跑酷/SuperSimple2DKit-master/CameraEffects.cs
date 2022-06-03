using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/*当玩家出拳或受伤时，镜头可以晃动。在这个脚本中放入任何其他自定义相机效果!*/

public class CameraEffects : MonoBehaviour
{
    public Vector3 cameraWorldSize;
    public CinemachineFramingTransposer cinemachineFramingTransposer;
    [SerializeField] private CinemachineBasicMultiChannelPerlin multiChannelPerlin;
    public float screenYDefault;
    public float screenYTalking;
    [Range(0, 10)]
    [System.NonSerialized] public float shakeLength = 10;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        //确保我们可以摇相机使用Cinemachine。不用太担心这些奇怪的东西。它只是Cinemachine的变量。
        cinemachineFramingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        screenYDefault = cinemachineFramingTransposer.m_ScreenX;

        //告诉玩家它应该控制什么相机效果，无论我们在什么场景。
        NewPlayer.Instance.cameraEffects = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        multiChannelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        //告诉virtualCamera接下来要做什么
        virtualCamera.Follow = NewPlayer.Instance.transform;
    }

    void Update()
    {
        multiChannelPerlin.m_FrequencyGain += (0 - multiChannelPerlin.m_FrequencyGain) * Time.deltaTime * (10 - shakeLength);
    }

    public void Shake(float shake, float length)
    {
        shakeLength = length;
        multiChannelPerlin.m_FrequencyGain = shake;
    }
}
