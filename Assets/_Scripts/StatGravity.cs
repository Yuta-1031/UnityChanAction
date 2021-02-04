using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatGravity : MonoBehaviour
{
    [SerializeField] GameObject hal_Player;
    [SerializeField] Footsteps.Hal_UnityChanController hal_Sc;
    [SerializeField] GameObject endGravity;

   /* private void Start()
    {
        //hal_Player = GameObject.FindWithTag("Player");
        hal_Sc = hal_Player.GetComponent<Footsteps.Hal_UnityChanController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        hal_Sc.noGravity();
        endGravity.SetActive(true);
        this.gameObject.SetActive(false);
    }*/
}

