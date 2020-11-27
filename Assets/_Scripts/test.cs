using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject player2;
 
    private bool pl_Change = true;

    private void Start()
    {
        player.SetActive(true);
        player2.SetActive(false);
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if(pl_Change == true)
            {
                player2.transform.position = player.transform.position;
                player2.transform.rotation = player.transform.rotation;
                
                player.SetActive(false);
                player2.SetActive(true);

                pl_Change = false;
            }
            else if(pl_Change == false)
            {
                player.transform.position = player2.transform.position;
                player.transform.rotation = player2.transform.rotation;
                
                player.SetActive(true);
                player2.SetActive(false);

                pl_Change = true;
            }
        }
    }
}