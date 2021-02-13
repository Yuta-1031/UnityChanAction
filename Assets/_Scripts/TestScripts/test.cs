using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Material mat;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material = mat;
    }
}
