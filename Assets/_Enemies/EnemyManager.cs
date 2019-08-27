using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Public References")]
    public MeshRenderer enemyMesh;

    [Header("Public Variables")]
    public float enemyHP;

    public void takeDamage(float damageAmount)
    {
        if (enemyHP > 0)
        {
            enemyHP -= damageAmount;
            StartCoroutine(HitFlashDelay(0.15f));
        }
        else if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator HitFlashDelay(float time)
    {
        enemyMesh.enabled = false;
        yield return new WaitForSeconds(time);
        enemyMesh.enabled = true;
        yield return new WaitForSeconds(time);
        enemyMesh.enabled = false;
        yield return new WaitForSeconds(time);
        enemyMesh.enabled = true;
        yield return new WaitForSeconds(time);
    }
}
