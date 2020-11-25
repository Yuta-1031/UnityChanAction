using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookTest : MonoBehaviour
{
    GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Lock"))
        {
            this.target = GameObject.FindWithTag("Enemy");
        }

        if (target != null)
        {
            transform.LookAt(target.transform);
            transform.rotation = new Quaternion(0, target.transform.rotation.y, 0, transform.rotation.w);
        }
    }
}
