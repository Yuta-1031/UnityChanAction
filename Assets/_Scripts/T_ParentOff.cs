using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_ParentOff : MonoBehaviour
{
    public GameObject hal_Uni;
    public GameObject parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var par_off = hal_Uni.GetComponent<Parent_Hal>();
            par_off.ParentOff();

            //Destroy(parent);
        }
    }
}
