using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTransparent : MonoBehaviour
{
    public Material templeMat;
    public Material templeDefMat;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "TempleWall")
        {
            other.gameObject.GetComponent<Renderer>().material = templeMat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "TempleWall")
        {
            other.gameObject.GetComponent<Renderer>().material = templeDefMat;
        }
    }
}
