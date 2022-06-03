using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackHit : MonoBehaviour
{
    private enum AttacksWhat { EnemyBase, NewPlayer };
    [SerializeField] private AttacksWhat attacksWhat;
    [SerializeField] private bool oneHitKill;
    [SerializeField] private float startCollisionDelay; 
    private int targetSide = 1; 
    [SerializeField] private GameObject parent; 
    [SerializeField] private bool isBomb = false; 
    [SerializeField] private int hitPower = 1; 

   
    void Start()
    {
        if (isBomb) StartCoroutine(TempColliderDisable());
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (parent.transform.position.x < col.transform.position.x)
        {
            targetSide = 1;
        }
        else
        {
            targetSide = -1;
        }


        //Attack Player
        if (attacksWhat == AttacksWhat.NewPlayer)
        {
            if (col.GetComponent<NewPlayer>() != null)
            {
                NewPlayer.Instance.GetHurt(targetSide, hitPower);
                if (isBomb) transform.parent.GetComponent<EnemyBase>().Die(); 
            }
        }

        //Attack Enemies
        else if (attacksWhat == AttacksWhat.EnemyBase && col.GetComponent<EnemyBase>() != null)
        {
            col.GetComponent<EnemyBase>().GetHurt(targetSide, hitPower);
        }

        //Attack Breakables
        else if (attacksWhat == AttacksWhat.EnemyBase && col.GetComponent<EnemyBase>() == null && col.GetComponent<Breakable>() != null)
        {
            col.GetComponent<Breakable>().GetHurt(hitPower);
        }

        //Blow up bombs if they touch walls
        if (isBomb && col.gameObject.layer == 8)
        {
            transform.parent.GetComponent<EnemyBase>().Die();
        }
    }

    IEnumerator TempColliderDisable()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;
        yield return new WaitForSeconds(startCollisionDelay);
        GetComponent<Collider2D>().enabled = true;
    }
}
