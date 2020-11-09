using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Change : MonoBehaviour
{
    private Transform player;
    private Transform offPlayer;
    private Transform cube;

    private void Start()
    {
        this.player = transform.Find("Player2");
        this.offPlayer = transform.Find("Player1");
    }
    public void Click()
    {
        player.gameObject.SetActive(false);
        offPlayer.gameObject.SetActive(true);
        //Debug.Log("click");
    }
}
