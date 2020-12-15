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

    public Transform muzzle8;
    public Transform muzzle9;
    public Transform muzzle10;
    public Transform muzzle11;
    public Transform muzzle12;
    public Transform muzzle13;
    public Transform muzzle14;
    public Transform muzzle15;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Arrow", 5, 5);   
    }

    void Arrow()
    {
        GameObject arrow = Instantiate(arrowPrefab,muzzle.position, muzzle.transform.rotation) as GameObject;
        GameObject arrow1 = Instantiate(arrowPrefab, muzzle1.position, muzzle1.rotation) as GameObject;
        GameObject arrow2 = Instantiate(arrowPrefab, muzzle2.position, muzzle2.rotation) as GameObject;
        GameObject arrow3 = Instantiate(arrowPrefab, muzzle3.position, muzzle3.rotation) as GameObject;
        GameObject arrow4 = Instantiate(arrowPrefab, muzzle4.position, muzzle4.rotation) as GameObject;
        GameObject arrow5 = Instantiate(arrowPrefab, muzzle5.position, muzzle5.rotation) as GameObject;
        GameObject arrow6 = Instantiate(arrowPrefab, muzzle6.position, muzzle6.rotation) as GameObject;
        GameObject arrow7 = Instantiate(arrowPrefab, muzzle7.position, muzzle7.rotation) as GameObject;
        GameObject arrow8 = Instantiate(arrowPrefab, muzzle8.position, muzzle8.rotation) as GameObject;
        GameObject arrow9 = Instantiate(arrowPrefab, muzzle9.position, muzzle9.rotation) as GameObject;
        GameObject arrow10 = Instantiate(arrowPrefab, muzzle10.position, muzzle10.rotation) as GameObject;
        GameObject arrow11 = Instantiate(arrowPrefab, muzzle11.position, muzzle11.rotation) as GameObject;
        GameObject arrow12 = Instantiate(arrowPrefab, muzzle12.position, muzzle12.rotation) as GameObject;
        GameObject arrow13 = Instantiate(arrowPrefab, muzzle13.position, muzzle13.rotation) as GameObject;
        GameObject arrow14 = Instantiate(arrowPrefab, muzzle14.position, muzzle14.rotation) as GameObject;
        GameObject arrow15 = Instantiate(arrowPrefab, muzzle15.position, muzzle15.rotation) as GameObject;

        arrow8.transform.rotation = muzzle8.rotation;
        arrow9.transform.rotation = muzzle9.rotation;
        arrow10.transform.rotation = muzzle10.rotation;
        arrow11.transform.rotation = muzzle11.rotation;
        arrow12.transform.rotation = muzzle12.rotation;
        arrow13.transform.rotation = muzzle13.rotation;
        arrow14.transform.rotation = muzzle14.rotation;
        arrow15.transform.rotation = muzzle15.rotation;
    }
}
