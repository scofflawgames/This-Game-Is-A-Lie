using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMelee : MonoBehaviour
{
    [Header("Public References")]
    public GameObject rightHandCollider;

    public void ActivateRightHand()
    {
        rightHandCollider.SetActive(true);
    }

    public void DeactiveRightHand()
    {
        rightHandCollider.SetActive(false);
    }


}
