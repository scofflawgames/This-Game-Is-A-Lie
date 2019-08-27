using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReciever : MonoBehaviour
{
    public enum VictimType {Player, Enemy}
    public VictimType victimType;
    
    public void DamageRecieved(float damageAmount)
    {
        if (victimType == VictimType.Player)
        {
            PlayerManager playerManager = FindObjectOfType<PlayerManager>();
            playerManager.playerHealth -= damageAmount;
            playerManager.RefreshUI();
            //print("Player has " + playerManager.playerHealth + " health now.");
        }
        else if (victimType == VictimType.Enemy)
        {
            EnemyManager enemyManager = FindObjectOfType<EnemyManager>();
            print("HIT ENEMY!!");
            if (enemyManager != null)
            {
                enemyManager.takeDamage(damageAmount);
                GameManager.score += 50;
                GameManager gameManager = FindObjectOfType<GameManager>();
                gameManager.ScoreUpdate();
            }
        }
    }
}
