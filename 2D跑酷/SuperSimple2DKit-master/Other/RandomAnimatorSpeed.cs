using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*将它附加到任何带有Animator组件的对象上。它将在检查器中设置的high和low值之间随机浮动动画速度!*/

public class RandomAnimatorSpeed : MonoBehaviour
{

    private Animator animator;
    [SerializeField] float low = .3f;
    [SerializeField] float high = 1.5f;

    // 使用它进行初始化
    void Start()
    {
        animator = GetComponent<Animator>() as Animator;
        animator.speed = Random.Range(low, high);
    }
}
