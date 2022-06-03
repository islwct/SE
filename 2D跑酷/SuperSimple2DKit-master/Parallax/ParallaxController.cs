using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*找到所有带有ParallaxLayer.cs脚本的游戏对象，并移动它们!*/

public class ParallaxController : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float cameraPositionChangeX, float cameraPositionChangeY);
    public ParallaxCameraDelegate onCameraMove;
    private Vector2 oldCameraPosition;
    List<ParallaxLayer> parallaxLayers = new List<ParallaxLayer>();

    Camera cam;

    void Start()
    {
        cam = Camera.main;
        onCameraMove += MoveLayer;
        FindLayers();
        oldCameraPosition.x = cam.transform.position.x;
        oldCameraPosition.y = cam.transform.position.y;
    }

    private void FixedUpdate()
    {
        if (cam.transform.position.x != oldCameraPosition.x || (cam.transform.position.y) != oldCameraPosition.y)
        {
            if (onCameraMove != null)
            {
                Vector2 cameraPositionChange;
                cameraPositionChange = new Vector2(oldCameraPosition.x - cam.transform.position.x, oldCameraPosition.y - cam.transform.position.y);
                onCameraMove(cameraPositionChange.x, cameraPositionChange.y);
            }

            oldCameraPosition = new Vector2(cam.transform.position.x, cam.transform.position.y);
        }
    }

    //找到所有带有ParallaxLayer组件的对象，并将它们添加到parallaxLayers列表中
    void FindLayers()
    {
        parallaxLayers.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            ParallaxLayer layer = transform.GetChild(i).GetComponent<ParallaxLayer>();

            if (layer != null)
            {
                parallaxLayers.Add(layer);
            }
        }
    }

    //根据每个层的位置移动每个层。
    void MoveLayer(float positionChangeX, float positionChangeY)
    {
        foreach (ParallaxLayer layer in parallaxLayers)
        {
            layer.MoveLayer(positionChangeX, positionChangeY);
        }
    }
}