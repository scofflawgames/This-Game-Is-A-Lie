using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReciever : MonoBehaviour
{
    public enum VictimType {Player, Enemy}
    public VictimType victimType;
    
    void Start()
    {

    }

    public void DamageRecieved(float damageAmount)
    {
        if (victimType == VictimType.Player)
        {
            PlayerManager playerManager = FindObjectOfType<PlayerManager>();
            playerManager.playerHealth -= damageAmount;
            playerManager.RefreshUI();
            //print("Player has " + playerManager.playerHealth + " health now.");
        }
    }
}
