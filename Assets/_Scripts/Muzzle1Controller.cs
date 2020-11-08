using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle1Controller : MonoBehaviour
{
    public GameObject arrowPrefab;
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
        InvokeRepeating("Arrow", 3, 3);
    }

    void Arrow()
    {
        GameObject arrow8 = Instantiate(arrowPrefab, muzzle8.position, arrowPrefab.transform.rotation) as GameObject;
        GameObject arrow9 = Instantiate(arrowPrefab, muzzle9.position, arrowPrefab.transform.rotation) as GameObject;
        GameObject arrow10 = Instantiate(arrowPrefab, muzzle10.position, arrowPrefab.transform.rotation) as GameObject;
        GameObject arrow11 = Instantiate(arrowPrefab, muzzle11.position, arrowPrefab.transform.rotation) as GameObject;
        GameObject arrow12 = Instantiate(arrowPrefab, muzzle12.position, arrowPrefab.transform.rotation) as GameObject;
        GameObject arrow13 = Instantiate(arrowPrefab, muzzle13.position, arrowPrefab.transform.rotation) as GameObject;
        GameObject arrow14 = Instantiate(arrowPrefab, muzzle14.position, arrowPrefab.transform.rotation) as GameObject;
        GameObject arrow15 = Instantiate(arrowPrefab, muzzle15.position, arrowPrefab.transform.rotation) as GameObject;
    }
}
