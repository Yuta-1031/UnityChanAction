using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]


public class UniAction : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] Transform cam;
    private Animator animator;
    Rigidbody rb;
    CapsuleCollider caps;
    public CapsuleCollider swordCaps;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        caps = GetComponent<CapsuleCollider>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        //caps.center = new Vector3(0, 0.76f, 0);
        //caps.radius = 0.23f;
        //caps.height = 1.6f;
    }

    private void Update()
    {

        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        animator.SetFloat("X", x * 50);
        animator.SetFloat("Y", z * 50);

        if(z > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, cam.eulerAngles.y, transform.rotation.z));
        }

        transform.position += transform.forward * z + transform.right * x;

        if (Input.GetButtonDown("Fire1") && !animator.IsInTransition(0))
        {
            animator.SetBool("Attack", true);
        }

    }

    void AttackStart()
    {
        swordCaps.enabled = true;
    }
    void AttackEnd()
    {
        swordCaps.enabled = false;
        animator.SetBool("Attack", false);
    }

    public void Hit()
    {

    }
 
}

