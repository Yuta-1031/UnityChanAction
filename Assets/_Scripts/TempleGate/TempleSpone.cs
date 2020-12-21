using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleSpone : MonoBehaviour
{
    private GameObject[] player;
    private GameObject par;
    private GameObject hal_pl;
    Parent_Hal plSc;

    private void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        player[0].transform.position = this.transform.position;
        player[1].transform.position = this.transform.position;
        Invoke("ParentSpone", 0.1f);
    }

    private void Start()
    {
        //hal_pl = GameObject.Find("Hal_UnityChan");

        //plSc = hal_pl.GetComponent<Parent_Hal>();
        //plSc.ParentSerch();

    }
    private void Update()
    {
        //par = GameObject.FindWithTag("Parent");
        //par.transform.position = this.transform.position;
        
    }
    void ParentSpone()
    {
    }
}
