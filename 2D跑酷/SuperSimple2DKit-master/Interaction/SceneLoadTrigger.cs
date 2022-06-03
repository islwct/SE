using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*加载一个新的场景，同时也清除一定的缓存!*/

public class SceneLoadTrigger : MonoBehaviour
{

    [SerializeField] string loadSceneName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == NewPlayer.Instance.gameObject)
        {
            GameManager.Instance.hud.loadSceneName = loadSceneName;
            GameManager.Instance.inventory.Clear();
            GameManager.Instance.hud.animator.SetTrigger("coverScreen");
            enabled = false;
        }
    }
}
