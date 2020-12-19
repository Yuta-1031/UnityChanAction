using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAdd : MonoBehaviour
{
    [SerializeField] GameObject hal_Player;
    [SerializeField] Footsteps.Hal_UnityChanController halSc;
   //[SerializeField] GameObject endGravity;

    private void Start()
    {
        //hal_Player = GameObject.FindWithTag("Player");
        halSc = hal_Player.GetComponent<Footsteps.Hal_UnityChanController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        halSc.gravity();

    }
    private void OnTriggerExit(Collider other)
    {
        halSc.noGravity();
    }
}
