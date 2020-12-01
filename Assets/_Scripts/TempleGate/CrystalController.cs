using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    public GameObject ps;
    public GameObject gate1;

    private void OnCollisionEnter(Collision other)
    {
       //Debug.Log(other.gameObject.tag);
        if(other.collider.gameObject.tag == "Sword")
        {
            Instantiate(ps, this.transform.position, Quaternion.identity);
            Destroy(this.gate1);
            Destroy(this.gameObject, 0.2f);
        }
    }
}
