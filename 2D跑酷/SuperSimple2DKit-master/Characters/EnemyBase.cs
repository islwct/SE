using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*EnemyFlyer和EnemyWalker的核心功能*/

[RequireComponent(typeof(RecoveryCounter))]

public class EnemyBase : MonoBehaviour
{
    [Header ("Reference")]
    [System.NonSerialized] public AudioSource audioSource;
    public Animator animator;
    private AnimatorFunctions animatorFunctions;
    [SerializeField] Instantiator instantiator;
    [System.NonSerialized] public RecoveryCounter recoveryCounter;

    [Header ("Properties")]
    [SerializeField] private GameObject deathParticles;
    [SerializeField] private int health = 3;
    public AudioClip hitSound;
    public bool isBomb;
    [SerializeField] bool requirePoundAttack; //要求玩家使用down攻击来伤害

    void Start()
    {
        recoveryCounter = GetComponent<RecoveryCounter>();
        audioSource = GetComponent<AudioSource>();
        animatorFunctions = GetComponent<AnimatorFunctions>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void GetHurt(int launchDirection, int hitPower)
    {
        //击中敌人，造成伤害效果，并减少生命值。允许需要向下的磅攻击
        if ((GetComponent<Walker>() != null || GetComponent<Flyer>() != null) && !recoveryCounter.recovering)
        {
            if (!requirePoundAttack || (requirePoundAttack && NewPlayer.Instance.pounding))
            {
                NewPlayer.Instance.cameraEffects.Shake(100, 1);
                health -= hitPower;
                animator.SetTrigger("hurt");

                audioSource.pitch = (1);
                audioSource.PlayOneShot(hitSound);

                //确保敌人和玩家不能在最大恢复时间内互相攻击
                recoveryCounter.counter = 0;
                NewPlayer.Instance.recoveryCounter.counter = 0;

                if (NewPlayer.Instance.pounding)
                {
                    NewPlayer.Instance.PoundEffect();
                }


                //地面敌人在被击中后发射与飞行者在被击中后略有不同.
                if (GetComponent<Walker>() != null)
                {
                    Walker walker = GetComponent<Walker>();
                    walker.launch = launchDirection * walker.hurtLaunchPower / 5;
                    walker.velocity.y = walker.hurtLaunchPower;
                    walker.directionSmooth = launchDirection;
                    walker.direction = walker.directionSmooth;
                }

                if (GetComponent<Flyer>() != null)
                {
                    Flyer flyer = GetComponent<Flyer>();
                    flyer.speedEased.x = launchDirection * 5;
                    flyer.speedEased.y = 4;
                    flyer.speed.x = flyer.speedEased.x;
                    flyer.speed.y = flyer.speedEased.y;
                }

                NewPlayer.Instance.FreezeFrameEffect();
            }
        }
    }

    public void Die()
    {
        if (NewPlayer.Instance.pounding)
        {
            NewPlayer.Instance.PoundEffect();
        }

        NewPlayer.Instance.cameraEffects.Shake(200, 1);
        health = 0;
        deathParticles.SetActive(true);
        deathParticles.transform.parent = transform.parent;
        instantiator.InstantiateObjects();
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}