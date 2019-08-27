using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{   
    public enum ItemType {HealthIncrease, DataIncrease, SanityIncrease}

    [Header("Public References")]
    public ItemType itemType;

    [Header("Public Variables")]
    public float increaseAmount;

    private PlayerManager playerManager;

    public void pickupItem()
    {
        if (itemType == ItemType.HealthIncrease)
        {
            playerManager = FindObjectOfType<PlayerManager>();
            playerManager.playerHealth += increaseAmount;
            playerManager.RefreshUI();
            Destroy(gameObject);
        }
    }
}
