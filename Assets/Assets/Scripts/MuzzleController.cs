using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleController : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform muzzle;
    public Transform muzzle1;
    public Transform muzzle2;
    public Transform muzzle3;
    public Transform muzzle4;
    public Transform muzzle5;
    public Transform muzzle6;
    public Transform muzzle7;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Arrow", 3, 3);   
    }

    void Arrow()
    {
        GameObject arrow = Instantiate(arrowPrefab,muzzle.position, arrowPrefab.transform.rotation) as GameObject;
        GameObject arrow1 = Instantiate(arrowPrefab, muzzle1.position, arrowPrefab.transform.rotation) as GameObject;
        GameObject arrow2 = Instantiate(arrowPrefab, muzzle2.position, arrowPrefab.transform.rotation) as GameObject;
        GameObject arrow3 = Instantiate(arrowPrefab, muzzle3.position, arrowPrefab.transform.rotation) as GameObject;
        GameObject arrow4 = Instantiate(arrowPrefab, muzzle4.position, arrowPrefab.transform.rotation) as GameObject;
        GameObject arrow5 = Instantiate(arrowPrefab, muzzle5.position, arrowPrefab.transform.rotation) as GameObject;
        GameObject arrow6 = Instantiate(arrowPrefab, muzzle6.position, arrowPrefab.transform.rotation) as GameObject;
        GameObject arrow7 = Instantiate(arrowPrefab, muzzle7.position, arrowPrefab.transform.rotation) as GameObject;
    }
}
