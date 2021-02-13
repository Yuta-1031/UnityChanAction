using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NavMeshAgent))]

public class ArthurMove : MonoBehaviour
{
    [SerializeField] private LayerMask raycastLayerMask;
    [SerializeField] CapsuleCollider swordCollider;
    private Animator thisAni;
    private NavMeshAgent _agent;
    private RaycastHit[] _raycastHits = new RaycastHit[10];
    private bool attacking = false;
    private float attackInterval = 1;
    public bool moveEnabled = true;
    public int arthurHP = 100;
    public int deadTime = 3;

    private SearchEnemy searchEnemy;
    private void Start()
    {
        this.thisAni = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    public void OnDetectObject(Collider col)
    {
        if (col.gameObject.tag =="Player" || col.gameObject.CompareTag("Player"))
        {
            if(moveEnabled == true)
            {
                var positionDiff = col.transform.position - transform.position;
                var distance = positionDiff.magnitude;
                var direction = positionDiff.normalized;

                var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits, distance);
                _agent.isStopped = false;
                _agent.destination = col.transform.position;

                if (hitCount == 2)
                {
                }
                else
                {
                    _agent.isStopped = true;
                }
            }
            else
            {
                _agent.isStopped = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Sword")
        {
            this.arthurHP -= 10;
        }
        else if(collision.gameObject.tag == "Fire")
        {
            this.arthurHP -= 5;
        }
    }

    public void OnAttack(Collider co)
    {
        if (co.CompareTag("Player"))
        {
            StartCoroutine(AttackTimer());
        }
    }

    IEnumerator AttackTimer()
    {
        if (!attacking)
        {
            attacking = true;
            moveEnabled = false;
            swordCollider.enabled = true;

            thisAni.SetTrigger("Attack");
         

            yield return new WaitForSeconds(attackInterval);

            attacking = false;
            moveEnabled = true;
            swordCollider.enabled = false;
        }

        yield return null;
    }

    IEnumerator OnDie()
    {
        moveEnabled = false;
        thisAni.SetTrigger("Die");
        yield return new WaitForSeconds(deadTime);
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(moveEnabled == true)
        {
            thisAni.SetFloat("MoveSpeed", _agent.velocity.magnitude);
        }

        if(arthurHP <= 0)
        {
            StartCoroutine(OnDie());
        }
        //Debug.Log(arthurHP);
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
