using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PampkinController : MonoBehaviour
{
    private Rigidbody _rig;
    public GameObject explosion;

    private void Start()
    {
        _rig = GetComponent<Rigidbody>();
        _rig.useGravity = false;

        Invoke("OnGravity", 0.4f);
    }

    void OnGravity()
    {
        _rig.useGravity = true;
        _rig.AddForce(transform.forward * -7.0f, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z), Quaternion.identity);
        Destroy(this.gameObject, 0.1f);
    }
}
