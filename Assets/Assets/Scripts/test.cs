using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public float speed = 3f;
    public float jumpSpeed = 3f;

    private Rigidbody rb;
    private float h, v;
    private Vector3 moveDirection = Vector3.zero;
    private bool isGrounded = false;
    private Vector3 latestPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        //足元から下へ向けてRayを発射し，着地判定をする
        isGrounded = Physics.Raycast(gameObject.transform.position + 0.1f * gameObject.transform.up, -gameObject.transform.up, 0.15f);
        //デバッグ用にシーンにRayを表示する
        Debug.DrawRay(gameObject.transform.position + 0.1f * gameObject.transform.up, -0.15f * gameObject.transform.up, Color.blue);

        if (isGrounded || Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            if (h != 0 || v != 0)
            {
                moveDirection = speed * new Vector3(h, 0, v);
                moveDirection = transform.TransformDirection(moveDirection);
                rb.velocity = moveDirection;
            }
            Vector3 diff = transform.position - latestPos;

            if (diff.magnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation(diff);
            }
            latestPos = transform.position;
        }

    }

}