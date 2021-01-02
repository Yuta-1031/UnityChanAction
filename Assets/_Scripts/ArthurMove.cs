using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]

public class ArthurMove : MonoBehaviour
{
    private Animator thisAni;
    private NavMeshAgent _agent;
    private RaycastHit[] _raycasthit = new RaycastHit[10];

    private void Start()
    {
        this.thisAni = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    public void  OnDetectObject(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            var positionDiff = collider.transform.position - transform.position;
            var distance = positionDiff.magnitude;
            var direction = positionDiff.normalized;

            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycasthit, distance);
            Debug.Log("hitCount: " + hitCount);

            if(hitCount == 1)
            {
                _agent.isStopped = false;
                _agent.destination = collider.transform.position;
            }
            else
            {
                _agent.isStopped = true;
            }
        }
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
