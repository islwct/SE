using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*旋转一个2D游戏对象*/

public class RotateObject : MonoBehaviour
{

    [SerializeField] float speed = 1;

    void Update()
    {
        transform.Rotate(Vector3.back * Time.deltaTime * speed);
    }
}
