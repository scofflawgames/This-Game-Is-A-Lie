using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Public References")]
    public Transform endPoint;
    public GameObject laserBeam;
    public Camera mainCamera;
    public PlayerManager playerManager;

    [Header("Public Variables")]
    public float projectileForce;


    private void FixedUpdate()
    {
        //SpecialAttack();
    }

    private void SpecialAttack()
    {
        if (Input.GetMouseButtonDown(0) && PlayerAttributes.sanity > 25)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.point.x > transform.position.x)
                {
                    GameObject laserBeamOBJ = Instantiate(laserBeam, endPoint);
                    Rigidbody laserBeamRB = laserBeamOBJ.GetComponent<Rigidbody>();
                    laserBeamRB.AddForce(transform.forward * projectileForce);
                }
                else if (hit.point.x < transform.position.x)
                {
                    GameObject laserBeamOBJ = Instantiate(laserBeam, endPoint);
                    Rigidbody laserBeamRB = laserBeamOBJ.GetComponent<Rigidbody>();
                    laserBeamRB.AddForce(-transform.forward * projectileForce);
                }
            }

            PlayerAttributes.sanity -= 2;
            playerManager.RefreshUI();
        }
    }
}
