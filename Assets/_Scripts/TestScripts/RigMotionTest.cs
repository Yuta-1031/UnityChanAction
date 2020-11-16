using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigMotionTest : MonoBehaviour
{
    private TwoBoneIKConstraint r_Aram;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       this.r_Aram = GetComponent<TwoBoneIKConstraint>();
        this.anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        r_Aram.weight = 0f;
    }
}
