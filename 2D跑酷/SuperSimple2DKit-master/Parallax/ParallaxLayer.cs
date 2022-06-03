using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*允许控制器根据parallaxAmount移动每一层!*/

public class ParallaxLayer : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float parallaxAmount; //视差的数量!1模拟离镜头很近，-1模拟离镜头很远!
    [System.NonSerialized] public Vector3 newPosition;
    private bool adjusted = false;

    public void MoveLayer(float positionChangeX, float positionChangeY)
    {
        newPosition = transform.localPosition;
        newPosition.x -= positionChangeX * (-parallaxAmount * 40) * (Time.deltaTime);
        newPosition.y -= positionChangeY * (-parallaxAmount * 40) * (Time.deltaTime);
        transform.localPosition = newPosition;
    }

}
