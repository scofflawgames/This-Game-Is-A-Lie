using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [Header("Public Variables")]
    public static float sanity, data, stamina;
    public float maxSanity, maxData, maxStamina;
    public float sanityLossRate, dataLossRate, dataHealthLossRate;
    public static bool isInsane = false;

    private PlayerManager playerManager;


    private void Start()
    {
        sanity = maxSanity;
        data = maxData;

        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void Update()
    {
        if (sanity > 0)
        {
            sanity -= sanityLossRate * Time.deltaTime;           
        }

        if (data > 0)
        {
            data -= dataLossRate * Time.deltaTime;
        }

        if (sanity <= 0)
        {
            isInsane = true;
            //start going insane, hallucinating(visual/audio), game more difficult
        }

        if (data <= 0)
        {
            //start losing health
            losingHealth(dataHealthLossRate);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       ItemPickup itemPickup = other.gameObject.GetComponent<ItemPickup>();
        
        if (itemPickup != null)
        {
            itemPickup.pickupItem();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    public void losingHealth(float lossRate)
    {
        playerManager.playerHealth -= lossRate * Time.deltaTime;
    }

}
