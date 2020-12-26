using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]

public class ArthurMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.destination = new Vector3(player.transform.position.x, player.transform.position.y - 1f, player.transform.position.z);
    }
}
