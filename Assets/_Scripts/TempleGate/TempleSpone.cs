using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleSpone : MonoBehaviour
{
    private void Awake()
    {
        GameManager.instance.playerOn = true;
        GameManager.instance.player.SetActive(true);
       //GameManager.instance.player2.SetActive(true);
        GameManager.instance.player.transform.position = this.transform.position;
        GameManager.instance.player2.transform.position = this.transform.position;
        GameManager.instance.cam.transform.position = this.transform.position;
    }
}
