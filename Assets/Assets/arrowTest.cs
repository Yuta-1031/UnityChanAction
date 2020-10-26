using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowTest : MonoBehaviour
{
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 force = new Vector3(0, 0, 90f);
        rb.AddForce(force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

        //Debug.Log(collision.gameObject.name);
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        Destroy(this.gameObject, 2f);
    }
}
