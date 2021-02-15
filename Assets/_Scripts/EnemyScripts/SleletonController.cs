using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SleletonController : MonoBehaviour
{
    public int this_HP;
    private float attackInterval = 1.5f;
    private Animator anim;
    private NavMeshAgent _agent;
    private RaycastHit[] _raycastHits = new RaycastHit[10];
    private Footsteps.TopDownController playerCS;
    private GameObject player;
    private bool moveEnabled = true;
    private bool attacking;
    public Material[] defColor;
    public Material[] damaColor;
    public Material[] transparent;
    public Renderer rend;
    public Transform effectPos;
    public GameObject effect;
    public GameObject lineEff;
    public GameObject destroyEff;
    public GameObject hitEff;
    private bool onDie;

    void Start()
    {
        anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        playerCS = player.GetComponent<Footsteps.TopDownController>();
    }

    void Update()
    {
        if (moveEnabled)
        {
            anim.SetFloat("Speed", _agent.velocity.magnitude);
        }

        if(onDie == true)
        {
             _agent.isStopped = true;
        }

        if (this_HP <= 0 && onDie == false)
        {
            OnDie();
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

    public void BeAttacked(Collider attackCol)
    {
        if (attackCol.gameObject.tag == "Sword" && playerCS.casueDamege == true && onDie == false)
        {
            this_HP -= 10;
            Instantiate(hitEff, effectPos);
            rend.GetComponent<Renderer>().materials = damaColor;
            Invoke("DefaultColor", 0.2f);
        }
    }

    private void DefaultColor()
    {
        if(this_HP > 0)
        {
            rend.GetComponent<Renderer>().materials = defColor;
        }
    }

    private void OnDie()
    {
        onDie = true;
        anim.speed = 0;
        rend.GetComponent<Renderer>().materials = damaColor;
        Instantiate(effect, effectPos);

        Invoke("DestroyEffect", 1f);
    }

    private void DestroyEffect()
    {
        Instantiate(destroyEff, effectPos);
        Instantiate(lineEff, effectPos);
        Invoke("OnDestroy", 0.3f);
    }
    private void OnDestroy()
    {
        rend.GetComponent<Renderer>().materials = transparent;
    }

    private void OnTriggerExit(Collider other)
    {
        if(onDie == true && other.gameObject.tag == "SearchEnemyCol")
        {
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }
}