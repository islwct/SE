using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*：简单的脚本告诉Unity，如果它在场景中发现一个相同的东西，就销毁它*/

public class Startup : MonoBehaviour
{

    public bool dontDestroyOnLoad = false;
    
    void Awake()
    {
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
        if (GameObject.Find("Startup") != null && GameObject.Find("Startup").tag == "Startup")
        {
            Destroy(gameObject);
        }
    }
}
