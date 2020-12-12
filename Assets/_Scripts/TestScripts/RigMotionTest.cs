using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigMotionTest : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    private void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.up * 9.81f, ForceMode.Force);

        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(transform.up * -100, ForceMode.Force);
        }
    }
}
