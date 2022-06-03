using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryCounter : MonoBehaviour
{
    //它确保在玩家再次攻击之前，EnemyBase或Breakable必须恢复一定的时间长度。.

    //[System.NonSerialized] 

    public float recoveryTime = 1f;
    [System.NonSerialized] public float counter;
    [System.NonSerialized] public bool recovering = false;

    void Update()
    {
        if(counter <= recoveryTime)
        {
            counter += Time.deltaTime;
            recovering = true;
        }
        else
        {
            recovering = false;
        }
    }
}
