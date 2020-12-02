using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public GameObject ps;
    public GameObject gate2;

    private void OnCollisionEnter(Collision other)
    {
       //Debug.Log(other.gameObject.tag);
        if(other.collider.gameObject.tag == "Sword" || other.collider.gameObject.tag == "Fire")
        {
            Instantiate(ps, this.transform.position, Quaternion.identity);
            Destroy(this.gate2);
            Destroy(this.gameObject, 0.2f);
        }
    }
}
