using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent_Hal : MonoBehaviour
{
    private GameObject hal_Parent;
    //public GameObject gate;

    private void Start()
    {
        ParentSerch();
    }

    public void ParentSerch()
    {
        hal_Parent = GameObject.FindWithTag("Parent");
        this.gameObject.transform.parent = hal_Parent.gameObject.transform;
    }

    public void ParentOff()
    {
        this.gameObject.transform.parent = null;

    }

}
