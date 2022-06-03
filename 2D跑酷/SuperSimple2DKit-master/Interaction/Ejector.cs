using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*将此附加到任何可收集物品上。当它从一个破碎的盒子或死亡的敌人中出现时，这将会启动。*/

public class Ejector : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bounceSound;
    [SerializeField] private BoxCollider2D collectableTrigger;
    private float counter; //Counts to a value, and then allows the collectable can be collected
    public bool launchOnStart;
    private Vector2 launchPower = new Vector2(300,300);
    private Rigidbody2D rb;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        if (launchOnStart)
        {
            Launch(launchPower);
            collectableTrigger.enabled = false;
        }
        else
        {
            rb.isKinematic = true;
            GetComponent<Collider2D>().enabled = false;
            collectableTrigger.enabled = true;
        }
    }

    void Update()
    {
        if (collectableTrigger != null && counter > .5f)
        {
            collectableTrigger.enabled = true;
        }
        else if (collectableTrigger != null)
        {
            counter += Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (launchOnStart && collectableTrigger.enabled)
        {
            audioSource.PlayOneShot(bounceSound, rb.velocity.magnitude / 10 * audioSource.volume);
        }
    }

    public void Launch(Vector2 launchPower)
    {
        rb.AddForce(new Vector2(launchPower.x * Random.Range(-1f, 1f), launchPower.y * Random.Range(1f, 1.5f)));
    }

}
