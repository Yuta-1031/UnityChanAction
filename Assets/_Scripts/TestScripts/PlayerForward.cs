using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    private Transform followTfm;
    //private Vector3 pos;

    float smoothTime = 0.5f;

    Vector3 velocity = Vector3.zero;

    void Start()
    {
    }

   void FixedUpdate()
    {
        followTfm = GameObject.FindGameObjectWithTag("Player2").transform;
        //pos = GameObject.FindGameObjectWithTag("Player2").transform.position;
        //transform.position = new Vector3(pos.x + 0.3f, pos.y + 2f, pos.z - 0.5f);
        transform.rotation = followTfm.transform.rotation;
        Vector3 targetPos = followTfm.TransformPoint(new Vector3(0.3f, 1.5f, -0.5f));
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
