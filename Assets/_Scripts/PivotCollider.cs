using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotCollider : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] Transform hal_end;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            if (GameManager.instance.pl_Change)
            {
                Vector3 pivotPosition = (start.position + end.position) / 2;
                transform.position = pivotPosition;

                Vector3 dir = end.position - transform.position;
                transform.forward = dir;
                BoxCollider col = GetComponent<BoxCollider>();
                float distance = Vector3.Distance(start.position, end.position);
                col.size = new Vector3(col.size.x, col.size.y, distance);
            }
            else
            {
                Vector3 pivotPosition = (start.position + hal_end.position) / 2;
                transform.position = pivotPosition;

                Vector3 dir = hal_end.position - transform.position;
                transform.forward = dir;
                BoxCollider col = GetComponent<BoxCollider>();
                float distance = Vector3.Distance(start.position, hal_end.position);
                col.size = new Vector3(col.size.x, col.size.y, distance);
            }
        }
    }
}
