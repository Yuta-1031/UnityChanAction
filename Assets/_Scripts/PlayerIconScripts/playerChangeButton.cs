using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerChangeButton : MonoBehaviour
{
    private Transform player;
    private Transform offPlayer;
    private Transform cube;

    private void Start()
    {
        //this.cube = transform.Find("Cube");
        this.player = transform.Find("Player1");
        this.offPlayer = transform.Find("Player2");
    }
    public void OnClick()
    {
        //cube.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        offPlayer.gameObject.SetActive(true);
        //Debug.Log("click");
    }
}
