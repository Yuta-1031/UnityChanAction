using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent_Hal : MonoBehaviour
{
    private GameObject hal_Parent;
    //public GameObject gate;

    private void Awake()
    {
        ParentSerch();
    }

    public void ParentSerch()
    {
        hal_Parent = GameObject.Find("Hal_Parent");
        this.gameObject.transform.parent = hal_Parent.gameObject.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == ("ChangeGate"))
        {
            this.gameObject.transform.parent = null;
        }
    }

}
