using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleSpone : MonoBehaviour
{
    public ParticleSystem sponeEff;
    public ParticleSystem sponeExplosion;

    private void Awake()
    {
        GameManager.instance.playerOn = true;
       //GameManager.instance.player2.SetActive(true);
        GameManager.instance.cam.transform.position = this.transform.position;
        GameManager.instance.player.transform.position = this.transform.position;
        GameManager.instance.player2.transform.position = this.transform.position;
        Invoke("PlayerSpone", 3f);
        Invoke("SponeEffOn", 2.8f);

        sponeExplosion.Stop();
        sponeEff.Stop();
    }

    void PlayerSpone()
    {
        GameManager.instance.player.SetActive(true);
    }

    void SponeEffOn()
    {
        sponeExplosion.Play();
    }

    private void Start()
    {
        sponeEff.Play();
    }
}
