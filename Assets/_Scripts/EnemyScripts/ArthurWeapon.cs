using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArthurWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player1")
        {
            GameManager.instance.player1Life -= 5;
        }
        else if(other.gameObject.tag == "Player2")
        {
            GameManager.instance.player2Life -= 5;
        }
    }
}
