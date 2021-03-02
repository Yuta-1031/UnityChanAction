using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Diamondo_SC : MonoBehaviour
{
    public GameObject ps;
    public GameObject dia;
    public Renderer rend;
    public Material transparent;
    private SearchEnemy searchEnemy;

    private void Start()
    {
        searchEnemy = GetComponent<SearchEnemy>();
    }
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.collider.gameObject.tag == "Sword" || other.collider.gameObject.tag == "Fire")
        {
            Instantiate(ps, this.transform.position, Quaternion.identity);
            GateOpen op = dia.GetComponent<GateOpen>();
            op.OpenTimeLine();
            rend.GetComponent<Renderer>().material = transparent;
            Invoke("SetFalse", 5f);
        }
    }

    void SetFalse()
    {
            this.gameObject.SetActive(false);
    }
}
