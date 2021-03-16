using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    public GameObject ps;
    public GameObject diamondo_light;
    public GameObject dia;
    public Renderer rend;
    public Material transparent;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.tag == "Sword" || other.collider.gameObject.tag == "Bom")
        {
            Instantiate(ps, this.transform.position, Quaternion.identity);
            //GateOpen op = dia.GetComponent<GateOpen>();
            //op.OpenTimeLine();
            dia.SetActive(false);
            rend.GetComponent<Renderer>().material = transparent;
            diamondo_light.SetActive(false);
            Invoke("SetFalse", 5f);
        }
    }

    void SetFalse()
    {
        this.gameObject.SetActive(false);
    }
}
