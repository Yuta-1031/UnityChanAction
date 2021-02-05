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
        if (other.gameObject.CompareTag("Fire"))
        {
            //colorChange = 1;
            var parent = this.transform;
            GameObject effect = Instantiate(fireEffect) as GameObject;
            effect.transform.position = gameObject.transform.position;
            effect.transform.parent = this.transform;
            Destroy(effect, 5f);
            RedColor();
        }
    }

    void colorDef()
    {
        uwagi.GetComponent<Renderer>().sharedMaterial = _def;
        band.GetComponent<Renderer>().sharedMaterial = _def;
        leg.GetComponent<Renderer>().sharedMaterial = _def;
        shirts.GetComponent<Renderer>().sharedMaterial = _def;
        s_sode.GetComponent<Renderer>().sharedMaterial = _def;
    }

    void RedColor()
    {
        uwagi.GetComponent<Renderer>().sharedMaterial = _Red;
        band.GetComponent<Renderer>().sharedMaterial = _Red;
        leg.GetComponent<Renderer>().sharedMaterial = _Red;
        shirts.GetComponent<Renderer>().sharedMaterial = _Red;
        s_sode.GetComponent<Renderer>().sharedMaterial = _Red;
        Invoke("colorDef", 5f);
    }
}
