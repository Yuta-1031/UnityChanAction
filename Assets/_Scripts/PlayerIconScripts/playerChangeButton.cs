using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerChangeButton : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    private Transform player1Pos;
    private Transform player2Pos;
    private Transform cube;

    private void Start()
    {
        //this.cube = transform.Find("Cube");
        //this.player = GameObject.FindWithTag("Player1");
        //this.offPlayer = GameObject.FindWithTag("Player2");
    }
    public void OnClick()
    {
        player2.transform.position = player1.transform.position;
        player1.SetActive(false);
        player2.SetActive(true);

        /*if(player1 == true)
        {
            player1Pos = player1.transform.Find("Player");
            player2.gameObject.SetActive(true);
            player2Pos = player2.transform.Find("Hal_UnityChan");
            
            player1.gameObject.SetActive(false);
            player2Pos.transform.position = player1Pos.transform.position;
        }*/
    }
}
