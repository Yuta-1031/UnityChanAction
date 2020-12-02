using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Four_Crystal : MonoBehaviour
{
    public GameObject ps;
    public GameObject gate4;

    private void OnCollisionEnter(Collision other)
    {
       //Debug.Log(other.gameObject.tag);
        if(other.collider.gameObject.tag == "Sword" || other.collider.gameObject.tag == "Fire")
        {
            Instantiate(ps, this.transform.position, Quaternion.identity);
            Destroy(this.gate4);
            Destroy(this.gameObject, 0.2f);
        }
    }
}
