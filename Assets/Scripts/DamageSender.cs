using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class DamageSender : MonoBehaviour
{
    [Header("Public Variables")]
    public float damageAmount;

    private void Start()
    {
        
    }


    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageReciever damageReciever = other.gameObject.GetComponent<DamageReciever>();

        if (damageReciever != null)
        {
            print("Damage dealt in the amount of " + damageAmount);
            damageReciever.DamageRecieved(damageAmount);
        }
    }


}
