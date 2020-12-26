using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleSpone : MonoBehaviour
{
    private GameObject[] player;
    private GameObject _cam;

    private void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        _cam = GameObject.FindWithTag("MainCamera");

        player[0].transform.position = this.transform.position;
        player[1].transform.position = this.transform.position;
        _cam.transform.position = this.transform.position;
    }
}
