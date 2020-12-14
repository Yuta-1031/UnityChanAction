using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] GameObject hal_Pl;
    [SerializeField] Footsteps.Hal_UnityChanController hal_Sc;


    private void Start()
    {
      hal_Sc = hal_Pl.GetComponent<Footsteps.Hal_UnityChanController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        hal_Sc.noGravity();
    }
}
