using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMove : MonoBehaviour
{
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.target = GameObject.FindGameObjectWithTag("Player");
        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 2f, target.transform.position.z);
        this.transform.rotation = target.transform.rotation;
    }
}
