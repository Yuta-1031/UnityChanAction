using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WizardController : MonoBehaviour
{
    public float hp;
    public int damage;
    public Material defColor;
    public Material damColor;
    public Material weaponColor;
    public Material headColor;
    public Material transparent;
    public Renderer rend;
    public Renderer headRend;
    public Renderer weaponRend;
    public ParticleSystem circle;
    public ParticleSystem explosion;
    [SerializeField] GameObject attackCollider;

    Animator anim;
    public GameObject playerPos;
    NavMeshAgent _agent;

    bool attacking;
    bool onDie;
    bool moveEnabled = true;
    bool attackEnable = true;
    bool receiveDamage = true;
    float attackInterval = 3f;
    RaycastHit[] _raycastHits = new RaycastHit[10];

    private void Start()
    {
        anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

        circle.Stop();
        explosion.Stop();
        attackCollider.SetActive(false);
    }

    private void Update()
    {
        if (moveEnabled)
        {
            anim.SetFloat("Speed", _agent.velocity.magnitude);
        }

        if (onDie)
        {
            _agent.speed = 0;
        }

        if(hp <=  0 && !onDie)
        {
            //onDie();
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
            playerPos.transform.position = co.transform.position;
            StartCoroutine(AttackTimer());
        }
    }

    IEnumerator AttackTimer()
    {
        if (!attacking)
        {
            attacking = true;
            moveEnabled = false;
            circle.transform.position = playerPos.transform.position;
            attackCollider.transform.position = playerPos.transform.position;
            explosion.transform.position = new Vector3(playerPos.transform.position.x, playerPos.transform.position.y + 1.5f, playerPos.transform.position.z);

            circle.Play();
            Invoke("Attack", 1f);
            Invoke("Explosion", 1.6f);

            yield return new WaitForSeconds(attackInterval);

            attacking = false;
            moveEnabled = true;

        }
        yield return null;
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        circle.Stop();
    }
    void Explosion()
    {
        explosion.Play();
        attackCollider.SetActive(true);
        Invoke("ColliderOff", 0.5f);
    }
    void ColliderOff()
    {
        attackCollider.SetActive(false);
        attackEnable = true;
    }

    public void Attaking(Collider col)
    {
        if (attackEnable && col.gameObject.tag == "Player")
        {
            GameManager.instance.ReceiveDamage(this.damage);
            attackEnable = false;
        }
    }
}
