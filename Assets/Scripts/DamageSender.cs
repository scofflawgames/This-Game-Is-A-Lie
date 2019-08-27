using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class DamageSender : MonoBehaviour
{
    [Header("Public Variables")]
    public float damageAmount;

    private void OnTriggerEnter(Collider other)
    {
        DamageReciever damageReciever = other.gameObject.GetComponent<DamageReciever>();

        if (damageReciever != null)
        {
            //print("Damage dealt in the amount of " + damageAmount);
            damageReciever.DamageRecieved(damageAmount);
            if (this.gameObject.CompareTag("Punch"))
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Play();
                    //add code to randomize pitch later
                }
            }
        }
    }

}
