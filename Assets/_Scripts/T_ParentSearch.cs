using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_ParentSearch : MonoBehaviour
{
    private GameObject hal_pl;

    void Start()
    {
       
        hal_pl = GameObject.Find("Hal_UnityChan");
        var Hal_SC = hal_pl.GetComponent<Parent_Hal>();
        Hal_SC.ParentSerch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
