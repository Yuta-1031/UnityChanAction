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
    public Collider thisCollider;
    public GameObject playerPos;
    public GameObject particleBody;
    public ParticleSystem circle;
    public ParticleSystem explosion;
    public ParticleSystem hitEff;
    public ParticleSystem bulleSmoke;
    public ParticleSystem destroySmoke;
    public ParticleSystem lineUp;
    [SerializeField] GameObject attackCollider;

    Animator anim;
    GameObject rotationTarget;
    NavMeshAgent _agent;

    bool attacking;
    bool onDie;
    bool moveEnabled = true;
    bool attackEnable = true;
    bool receiveDamage = true;
    float attackInterval = 5f;
    RaycastHit[] _raycastHits = new RaycastHit[10];

    private void Start()
    {
        anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

        circle.Stop();
        hitEff.Stop();
        lineUp.Stop();
        explosion.Stop();
        bulleSmoke.Stop();
        destroySmoke.Stop();

        circle.transform.parent = null;
        explosion.transform.parent = null;

        attackCollider.SetActive(false);
    }

    private void Update()
    {
        if (!rotationTarget)
        {
            return;
        }
        if (moveEnabled)
        {
            anim.SetFloat("Speed", _agent.velocity.magnitude);
        }

        if (onDie)
        {
            _agent.speed = 0;
        }

        if (hp <= 0 && !onDie)
        {
            OnDie();
        }

    }

    public void OnDetectObject(Collider col)
    {
        _agent.destination = col.transform.position;

        if (col.gameObject.tag == "Player")
        {
            if (moveEnabled)
            {
                var positionDiff = col.transform.position - transform.position;
                var distance = positionDiff.magnitude;
                var direction = positionDiff.normalized;

                var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits, distance);
                _agent.isStopped = false;

                rotationTarget = col.gameObject;

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
        if (!attacking && !onDie)
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
            transform.LookAt(rotationTarget.transform);

        }
        yield return null;
    }

    void Attack()
    {
        if (!onDie)
        {
            anim.SetTrigger("Attack");
            circle.Stop();
        }
        else
        {
            return;
        }
    }
    void Explosion()
    {
        if (!onDie)
        {
            explosion.Play();
            attackCollider.SetActive(true);
            Invoke("ColliderOff", 0.5f);
        }
        else
        {
            return;
        }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sword" && onDie == false && receiveDamage)
        {
            hp -= 10;
            anim.speed = 0.1f;
            receiveDamage = false;
            Invoke("SpeedDefault", 0.3f);
            Invoke("ScaleDefault", 0.1f);
            hitEff.Play();
            this.transform.localScale = Vector3.one * 0.25f;
            rend.material = damColor;
            headRend.material = damColor;
            weaponRend.material = damColor;
        }
        else if (collision.gameObject.tag == "Bom" && onDie == false && receiveDamage)
        {
            receiveDamage = false;
            hp -= 10;
            anim.speed = 0.1f;
            Invoke("SpeedDefault", 0.3f);
            Invoke("ScaleDefault", 0.1f);
            this.transform.localScale = Vector3.one * 0.25f;
            rend.material = damColor;
            headRend.material = damColor;
            weaponRend.material = damColor;
        }
    }

    private void ScaleDefault()
    {
        if (hp > 0)
        {
            this.transform.localScale = Vector3.one * 0.3f;
            receiveDamage = true;
        }
    }

    private void SpeedDefault()
    {
        if (hp > 0)
        {
            rend.material = defColor;
            headRend.material = defColor;
            weaponRend.material = defColor;
            anim.speed = 1.0f;
        }
    }

    private void OnDie()
    {
        onDie = true;
        anim.speed = 0;
        _agent.speed = 0f;
        thisCollider.enabled = false;
        rend.material = damColor;
        bulleSmoke.Play();

        Invoke("DestroyEffect", 1f);
    }

    private void DestroyEffect()
    {
        lineUp.Play();
        destroySmoke.Play();
        particleBody.SetActive(false);
        Invoke("OnDestroy", 0.3f);
    }
    private void OnDestroy()
    {
        rend.material = transparent;
        headRend.material = transparent;
        weaponRend.material = transparent;
        Invoke("SetFalse", 2f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (onDie == true && other.gameObject.tag == "SearchEnemyCol")
        {
            this.gameObject.SetActive(false);
        }
    }

    private void SetFalse()
    {
        this.gameObject.SetActive(false);
    }
}
