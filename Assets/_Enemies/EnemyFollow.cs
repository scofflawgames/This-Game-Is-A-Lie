using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyFollow : MonoBehaviour
{
    [Header("Public References")]
    public GameObject playerObject;
    public GameObject enemyObject;
    public RaycastHit DistanceDetection;

    [Header("Public Variables")]
    public float TargetDistance;
    public float AllowedDistance = 5;
    public float FollowSpeed;

    private NavMeshAgent enemyNavAgent;

    private void Start()
    {
        enemyNavAgent = GetComponent<NavMeshAgent>();
        //transform.LookAt(playerObject.transform);
    }

    private void Update()
    {
        enemyNavAgent.destination = playerObject.transform.position;
    }

}
