using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [Header("Public Variables")]
    public float playerHealth = 100;
    public static bool playerDead = false;

    [Header("Public References")]
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI playerDataText;
    public TextMeshProUGUI playerSanityText;
    public GameObject player;
    public MeshRenderer playerMesh;


    //private shit
    private GameManager gameManager;
    //private PlayerAttributes playerAttributes;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        RefreshUI();
    }

    private void Update()
    {
        //print(PlayerAttributes.data);
        playerDataText.text = ("DATA: " + PlayerAttributes.data);
        playerSanityText.text = ("SANITY: " + PlayerAttributes.sanity);

        if (PlayerAttributes.isInsane)
        {
            RefreshUI();
        }
    }

    public void RefreshUI()
    {
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            playerHealthText.text = ("HEALTH: " + playerHealth);
            playerDead = true;
            print("Game Over!! You and all your friends are dead!!!");
            Destroy(player);
            StartCoroutine(DeathDelay(3));
        }
        else
        {
            StartCoroutine(HitFlashDelay(0.15f));
            playerHealthText.text = ("HEALTH: " + playerHealth);
        }

    }

    IEnumerator DeathDelay(float time)
    {
        yield return new WaitForSeconds(time);
        gameManager.RestartGame();
    }

    IEnumerator HitFlashDelay(float time)
    {
        playerMesh.enabled = false;
        yield return new WaitForSeconds(time);
        playerMesh.enabled = true;
        yield return new WaitForSeconds(time);
        playerMesh.enabled = false;
        yield return new WaitForSeconds(time);
        playerMesh.enabled = true;
        yield return new WaitForSeconds(time);
    }
}
