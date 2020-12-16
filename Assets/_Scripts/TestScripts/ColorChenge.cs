using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChenge : MonoBehaviour
{
    public Material[] _material;
    private int i;

    private void Start()
    {
        i = 0;
        //ColorChenge();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            i++;
            //ColorChenge();
            if(i == 2)
            {
                i = 0;
            }
            this.GetComponent<Renderer>().sharedMaterial = _material[i];
        }
    }

    void Colorchenge()
    {
    }
}
