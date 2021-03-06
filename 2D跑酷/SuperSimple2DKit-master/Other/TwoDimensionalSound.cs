using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//尽管Unity有一个内置的2D声音系统，添加到任何带有audioSource的对象，以根据它在播放器中的位置来控制音量
public class TwoDimensionalSound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] float randomPitchAdder = 0;
    [SerializeField] float range;
    [SerializeField] float volume;
    [SerializeField] Vector3 distanceBetweenPlayer;
    [SerializeField] float magnitude;
    
    void Start()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        audioSource.pitch += Random.Range(-randomPitchAdder / 3, randomPitchAdder);
    }

    void Update()
    {
        distanceBetweenPlayer = transform.position - NewPlayer.Instance.transform.position;
        magnitude = (range - distanceBetweenPlayer.magnitude) / range;
        if (magnitude <= 1)
        {
            audioSource.volume = magnitude;
        }
        else
        {
            audioSource.volume = 1;
        }
    }
}
