using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderController : MonoBehaviour
{
    public int this_HP;
    public int damage = 5;
    public Renderer rend;
    public GameObject dieEff;
    public GameObject hitEff;
    public GameObject hitEff2;
    public GameObject lineEff;
    public GameObject smokeEff;
    public Material defColor;
    public Material damColor;
    public Material transparent;
    public Collider mainCol;
    public Transform effectPos;
    public Transform hitEffectPos;
    public ParticleSystem effect;
    public ParticleSystem effect2;
    public SphereCollider attackCol;
    private Animator anim;
    private NavMeshAgent _agent;
    private GameObject gameManager;
    private GameManager life;
    private bool onDie = false;
    private bool attacking = false;
    private bool moveEnabled = true;
    private bool receiveDamage = true;
    private float attackInterval = 1;
    private RaycastHit[] _raycastHits = new RaycastHit[10];

    void Start()
    {
        anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        life = gameManager.GetComponent<GameManager>();

        effect.Stop();
        effect2.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveEnabled)
        {
            anim.SetFloat("Speed", _agent.velocity.magnitude);
        }

        if(this_HP <= 0 && onDie == false)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (receiveDamage == true)
        {
            if (collision.gameObject.tag == "Sword" && this_HP > 0)
            {
                this_HP -= 10;
                Instantiate(hitEff, hitEffectPos);
                Instantiate(hitEff2, hitEffectPos);
                rend.GetComponent<Renderer>().material = damColor;
                Invoke("DefaultColor", 0.1f);
                receiveDamage = false;
            }
        }
    }

    void DefaultColor()
    {
        if(this_HP > 0)
        {
            rend.GetComponent<Renderer>().material = defColor;
            receiveDamage = true;
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
            life.ReceiveDamage(damage);
        }
    }
    private void DealDamage()
    {
        //Instantiate(effect, effectPos);
        effect.Play();
        effect2.Play();
        attackCol.enabled = true;
    }
    private void ColliderOff()
    {
        attackCol.enabled = false;
    }

    private void OnDie()
    {
        Debug.Log("die");
        onDie = true;
        _agent.speed = 0;
        anim.speed = 0f;
        mainCol.enabled = false;
        attackCol.enabled = false;
        Instantiate(dieEff, hitEffectPos);
        Invoke("Transparent", 2.0f);
    }

    private void Transparent()
    {
        Instantiate(lineEff, effectPos);
        Instantiate(smokeEff, effectPos);
        rend.GetComponent<Renderer>().material = transparent;
        Invoke("SetFalse", 2f);
    }

    private void SetFalse()
    {
        this.gameObject.SetActive(false);
    }
}
