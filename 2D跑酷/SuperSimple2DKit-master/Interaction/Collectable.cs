using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*用于硬币，生命值*/

public class Collectable : MonoBehaviour
{

    enum ItemType { InventoryItem, Coin, Health, Ammo }; 
    [SerializeField] ItemType itemType; 
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bounceSound;
    [SerializeField] private AudioClip[] collectSounds;
    [SerializeField] private int itemAmount;
    [SerializeField] private string itemName; 
    [SerializeField] private Sprite UIImage; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == NewPlayer.Instance.gameObject)
        {
            Collect();
        }

        if (col.gameObject.layer == 14)
        {
            Collect();
        }
    }

    public void Collect()
    {
        if (itemType == ItemType.InventoryItem)
        {
            if (itemName != "")
            {
                GameManager.Instance.GetInventoryItem(itemName, UIImage);
            }
        }
        else if (itemType == ItemType.Coin)
        {
            NewPlayer.Instance.coins += itemAmount;
        }
        else if (itemType == ItemType.Health)
        {
            if (NewPlayer.Instance.health < NewPlayer.Instance.maxHealth)
            {
                GameManager.Instance.hud.HealthBarHurt();
                NewPlayer.Instance.health += itemAmount;
            }
        }
        else if (itemType == ItemType.Ammo)
        {
            if (NewPlayer.Instance.ammo < NewPlayer.Instance.maxAmmo)
            {
                GameManager.Instance.hud.HealthBarHurt();
                NewPlayer.Instance.ammo += itemAmount;
            }
        }

        GameManager.Instance.audioSource.PlayOneShot(collectSounds[Random.Range(0, collectSounds.Length)], Random.Range(.6f, 1f));

        NewPlayer.Instance.FlashEffect();


        if (transform.parent.GetComponent<Ejector>() != null)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
