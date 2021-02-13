using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_MotionStop : MonoBehaviour
{

    [SerializeField] Animator playerAnim;

    void Start()
    {
        //playerAnim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            playerAnim.applyRootMotion = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            playerAnim.applyRootMotion = true;
        }
    }
}
