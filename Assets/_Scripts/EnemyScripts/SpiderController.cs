using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderController : MonoBehaviour
{
    public int tihi_HP;
    public GameObject effect;
    public Transform effectPos;
    private NavMeshAgent _agent;
    private Animator anim;
    public SphereCollider attackCol;
    private RaycastHit[] _raycastHits = new RaycastHit[10];
    private bool moveEnabled = true;
    private bool attacking = false;
    private float attackInterval = 1;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveEnabled)
        {
            anim.SetFloat("Speed", _agent.velocity.magnitude);
        }
    }

    public void OnDetectObject(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (moveEnabled)
            {
                var positionDiff = col.transform.position - transform.position;
                var distance = positionDiff.magnitude;
                var direction = positionDiff.normalized;

                var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits, distance);
                _agent.isStopped = false;
                _agent.destination = col.transform.position;

                if (hitCount > 4)
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

    public void OnAttack(Collider co)
    {
        if (co.gameObject.tag == "Player")
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
            anim.SetTrigger("Attack");

            yield return new WaitForSeconds(attackInterval);

            attacking = false;
            moveEnabled = true;
        }
        yield return null;
    }

    public void Damage(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.player1Life -= 2;
        }
        //GameManager.instance.player2Life -= 2;
    }
    private void DealDamage()
    {
        Instantiate(effect, effectPos);
        attackCol.enabled = true;
    }
    private void ColliderOff()
    {
        attackCol.enabled = false;
    }
}
