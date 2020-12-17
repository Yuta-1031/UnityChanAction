using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleSpone : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        //GameManager.instance.player.transform.position = this.transform.position;
        Instantiate(player, this.transform.position, Quaternion.identity);
    }
}
