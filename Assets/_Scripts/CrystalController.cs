using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
       //Debug.Log(other.gameObject.tag);
        if(other.collider.gameObject.tag == "Sword")
        {
            Destroy(this.gameObject);
        }
    }
}
