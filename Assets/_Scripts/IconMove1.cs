﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMove1 : MonoBehaviour
{
    private GameObject target;
    private float x = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.target = GameObject.FindGameObjectWithTag("Player");
        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 50f, target.transform.position.z);
        this.transform.rotation = target.transform.rotation;
        /*Vector3 angle = this.transform.eulerAngles;
        angle.x = this.target.transform.rotation.x;
        //angle.x = 90f;
        angle.y = this.target.transform.rotation.y;
        angle.z = this.target.transform.rotation.z;
        this.transform.eulerAngles = angle;*/
    }
}
