using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigMotionTest : MonoBehaviour
{
    public float time;
    public float delay;
    public float move_Y;
    private int frameCnt = 0;

    void Update()
    {
        //iTween.MoveTo(gameObject, iTween.Hash("Y", transform.position.y + 1f));
    }

    private void Start()
    {
        //iTween.MoveAdd(gameObject, iTween.Hash("Y", move_Y, "time", time,"delay", delay, "loopType", "pingPong"));
        //iTween.MoveAdd(gameObject, iTween.Hash("Y", -2f, "time", 2f, "delay", 1.0f, "loopType", "loop"));
    }

    private void FixedUpdate()
    {
        frameCnt += 1;

        if(10000 <= frameCnt)
        {
            frameCnt = 0;
        }

        if(0 == frameCnt % 2)
        {
            float posYSin = Mathf.Sin(2.0f * Mathf.PI * (float)(frameCnt % 200) / (200.0f - 1.0f));
            iTween.MoveAdd(gameObject, new Vector3(0, move_Y * posYSin, 0), 0.0f);
        }
    }
}
