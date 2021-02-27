using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SleletonController : MonoBehaviour
{
    public float hp;
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
    public TrailRenderer attackTrail;
    public Transform effectPos;
    public GameObject effect;
    public GameObject lineEff;
    public GameObject destroyEff;
    public GameObject hitEff;
    public CapsuleCollider caps;
    private bool onDie;
    private Collider thisCollider;
    private bool receiveDamage = true;

    EnemyHP _enemyHP;

    void Start()
    {
        anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        playerCS = player.GetComponent<Footsteps.TopDownController>();
        thisCollider = GetComponent<Collider>();
        attackTrail.emitting = false;
        caps.enabled = false;
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

        if (hp <= 0 && onDie == false)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sword" && onDie == false && receiveDamage)
        {
            hp -= 10;
            anim.speed = 0.1f;
            Invoke("SpeedDefault", 0.3f);
            Invoke("ScaleDefault", 0.1f);
            Instantiate(hitEff, effectPos);
            this.transform.localScale = Vector3.one * 0.65f;
            rend.GetComponent<Renderer>().materials = damaColor;
        }
        else if(collision.gameObject.tag == "Bom" && onDie == false && receiveDamage)
        {
            receiveDamage = false;
            hp -= 10;
            anim.speed = 0.1f;
            Invoke("SpeedDefault", 0.3f);
            Invoke("ScaleDefault", 0.1f);
            Instantiate(hitEff, effectPos);
            this.transform.localScale = Vector3.one * 0.65f;
            rend.GetComponent<Renderer>().materials = damaColor;
        }    
    }

    private void ScaleDefault()
    {
        if(hp > 0)
        {
            this.transform.localScale = Vector3.one * 0.7f;
            receiveDamage = true;
        }
    }

    private void SpeedDefault()
    {
        if(hp > 0)
        {
            rend.GetComponent<Renderer>().materials = defColor;
            anim.speed = 1.0f;
        }
    }

    private void OnDie()
    {
        onDie = true;
        anim.speed = 0;
        _agent.speed = 0f;
        thisCollider.enabled = false;
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
        Invoke("SetFalse", 2f);
    }

    private void OnTriggerExit(Collider other)
    {
        if(onDie == true && other.gameObject.tag == "SearchEnemyCol")
        {
            this.gameObject.SetActive(false);
        }
    }

    private void SetFalse()
    {
        this.gameObject.SetActive(false);
    }

    void AttackStart()
    {
        attackTrail.emitting = true;
        caps.enabled = true;
    }

    void AttackEnd()
    {
        attackTrail.emitting = false;
        caps.enabled = false;
    }
}