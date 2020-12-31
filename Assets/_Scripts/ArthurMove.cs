using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]

public class ArthurMove : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Animator thisAni;
    private NavMeshAgent _agent;

    private void Start()
    {
        this.thisAni = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //_agent.destination = new Vector3(player.transform.position.x, player.transform.position.y - 1f, player.transform.position.z);
    }

    public void ActiveAnimation()
    {
        thisAni.SetBool("Active", true);
    }

    public void AnimationOff()
    {
        thisAni.SetBool("Active", false);
    }
}
