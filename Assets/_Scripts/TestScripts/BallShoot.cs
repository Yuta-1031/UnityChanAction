using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShoot : MonoBehaviour
{
    [SerializeField] GameObject hal_Player;
    [SerializeField] Footsteps.Hal_UnityChanController hal_Sc;

    private void Start()
    {
        //hal_Player = GameObject.FindWithTag("Player");
        hal_Sc = hal_Player.GetComponent<Footsteps.Hal_UnityChanController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        hal_Sc.gravity();
    }

    private void OnTriggerExit(Collider other)
    {
        hal_Sc.noGravity();
    }
}
