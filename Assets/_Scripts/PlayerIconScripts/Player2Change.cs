using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Change : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject offPlayer;
    private Transform cube;

    private void Start()
    {
        //this.player = GameObject.FindWithTag("Player2");
        //this.offPlayer = GameObject.FindWithTag("Player1");
    }
    public void Click()
    {
        player.gameObject.SetActive(false);
        offPlayer.gameObject.SetActive(true);
        //Debug.Log("click");
    }
}
