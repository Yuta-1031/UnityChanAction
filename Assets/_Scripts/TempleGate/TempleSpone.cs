using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleSpone : MonoBehaviour
{
    private GameObject[] player;
    private GameObject parent;

    private void Awake()
    {
    }

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectsWithTag("Player");
        player[0].transform.position = this.transform.position;
        player[1].transform.position = this.transform.position;

        parent = GameObject.FindWithTag("Parent");
        parent.transform.position = this.transform.position;
        //Destroy(this.gameObject);
    }
}
