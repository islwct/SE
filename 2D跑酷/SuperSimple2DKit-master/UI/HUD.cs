using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/*管理和更新HUD，其中包含你的生命值条，货币等*/

public class HUD : MonoBehaviour
{
    [Header ("Reference")]
    public Animator animator;
    [SerializeField] private GameObject ammoBar;
    public TextMeshProUGUI coinsMesh;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Image inventoryItemGraphic;
    [SerializeField] private GameObject startUp;

    private float ammoBarWidth;
    private float ammoBarWidthEased; 
    [System.NonSerialized] public Sprite blankUI; 
    private float coins;
    private float coinsEased;
    private float healthBarWidth;
    private float healthBarWidthEased;
    [System.NonSerialized] public string loadSceneName;
    [System.NonSerialized] public bool resetPlayer;

    void Start()
    {
        
        healthBarWidth = 1;
        healthBarWidthEased = healthBarWidth;
        ammoBarWidth = 1;
        ammoBarWidthEased = ammoBarWidth;
        coins = (float)NewPlayer.Instance.coins;
        coinsEased = coins;
        blankUI = inventoryItemGraphic.GetComponent<Image>().sprite;
    }

    void Update()
    {
        
        coinsMesh.text = Mathf.Round(coinsEased).ToString();
        coinsEased += ((float)NewPlayer.Instance.coins - coinsEased) * Time.deltaTime * 5f;

        if (coinsEased >= coins)
        {
            animator.SetTrigger("getGem");
            coins = coinsEased + 1;
        }

        healthBarWidth = (float)NewPlayer.Instance.health / (float)NewPlayer.Instance.maxHealth;
        healthBarWidthEased += (healthBarWidth - healthBarWidthEased) * Time.deltaTime * healthBarWidthEased;
        healthBar.transform.localScale = new Vector2(healthBarWidthEased, 1);

        if (ammoBar)
        {
            ammoBarWidth = (float)NewPlayer.Instance.ammo / (float)NewPlayer.Instance.maxAmmo;
            ammoBarWidthEased += (ammoBarWidth - ammoBarWidthEased) * Time.deltaTime * ammoBarWidthEased;
            ammoBar.transform.localScale = new Vector2(ammoBarWidthEased, transform.localScale.y);
        }
        
    }

    public void HealthBarHurt()
    {
        animator.SetTrigger("hurt");
    }

    public void SetInventoryImage(Sprite image)
    {
        inventoryItemGraphic.sprite = image;
    }

    void ResetScene()
    {
        if (GameManager.Instance.inventory.ContainsKey("reachedCheckpoint"))
        {
            NewPlayer.Instance.ResetLevel();
        }
        else
        {
            SceneManager.LoadScene(loadSceneName);
        }
    }

}
