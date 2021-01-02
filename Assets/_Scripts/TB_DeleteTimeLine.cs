using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TB_DeleteTimeLine : MonoBehaviour
{
    public GameObject cam;
    public GameObject text1;
    public GameObject text2;
    public GameObject cube;

    public void Delete()
    {
        Destroy(cam);
        Destroy(text1);
        Destroy(text2);
        Destroy(cube);
    }

}
