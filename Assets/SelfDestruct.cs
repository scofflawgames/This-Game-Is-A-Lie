using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [Header("Public Variables")]
    public float destructTime = 3;

    
    void Start()
    {
       Destroy(gameObject, destructTime); 
    }

}
