using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*这个脚本可以用于几乎任何游戏对象。它提供了几个可用来调用的函数
动画窗口中的动画事件*/

public class AnimatorFunctions : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private Animator setBoolInAnimator;

    // 如果我们不指定通过什么音频源播放声音，只使用播放器上的一个。
    void Start()
    {
        if (!audioSource) audioSource = NewPlayer.Instance.audioSource;
    }

    //隐藏和打开玩家
    public void HidePlayer(bool hide)
    {
        NewPlayer.Instance.Hide(hide);
    }
  
    public void JumpPlayer(float power = 1f)
    {
        NewPlayer.Instance.Jump(power);
    }

    void FreezePlayer(bool freeze)
    {
        NewPlayer.Instance.Freeze(freeze);
    }

    void PlaySound(AudioClip whichSound)
    {
        audioSource.PlayOneShot(whichSound);
    }

    public void EmitParticles(int amount)
    {
        particleSystem.Emit(amount);
    }

    public void ScreenShake(float power)
    {
        NewPlayer.Instance.cameraEffects.Shake(power, 1f);
    }

    public void SetTimeScale(float time)
    {
        Time.timeScale = time;
    }

    public void SetAnimBoolToFalse(string boolName)
    {
        setBoolInAnimator.SetBool(boolName, false);
    }

    public void SetAnimBoolToTrue(string boolName)
    {
        setBoolInAnimator.SetBool(boolName, true);
    }

    public void FadeOutMusic()
    {
       GameManager.Instance.gameMusic.GetComponent<AudioTrigger>().maxVolume = 0f;
    }

    public void LoadScene(string whichLevel)
    {
        SceneManager.LoadScene(whichLevel);
    }

    public void SetTimeScaleTo(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
    