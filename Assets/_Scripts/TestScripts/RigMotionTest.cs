using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigMotionTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("h");
    }
}
