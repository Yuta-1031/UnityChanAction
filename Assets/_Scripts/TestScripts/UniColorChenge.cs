using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniColorChenge : MonoBehaviour
{
    public GameObject uwagi;
    //public GameObject sode;
    public GameObject band;
    public GameObject leg;
    public GameObject shirts;
    public GameObject s_sode;
    public Material _def;
    public Material _Red;
    public GameObject fireEffect;

    private int colorChange;


    private bool noPS = false;

    private void Start()
    {
        colorChange = 0;
        colorDef();
    }

    private void Update()
    {
        /*if(colorChange == 1)
        {
            RedColor();
        }*/
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Fire") && noPS == false)
        {
            //colorChange = 1;
            var parent = this.transform;
            GameObject effect = Instantiate(fireEffect) as GameObject;
            effect.transform.position = gameObject.transform.position;
            RedColor();
        }
    }

    void colorDef()
    {
        noPS = false;
        uwagi.GetComponent<Renderer>().sharedMaterial = _def;
        band.GetComponent<Renderer>().sharedMaterial = _def;
        leg.GetComponent<Renderer>().sharedMaterial = _def;
        shirts.GetComponent<Renderer>().sharedMaterial = _def;
        s_sode.GetComponent<Renderer>().sharedMaterial = _def;
    }

    void RedColor()
    {
        noPS = true;
        uwagi.GetComponent<Renderer>().sharedMaterial = _Red;
        band.GetComponent<Renderer>().sharedMaterial = _Red;
        leg.GetComponent<Renderer>().sharedMaterial = _Red;
        shirts.GetComponent<Renderer>().sharedMaterial = _Red;
        s_sode.GetComponent<Renderer>().sharedMaterial = _Red;
        Invoke("colorDef", 4.5f);
    }
}
