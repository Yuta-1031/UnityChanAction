using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameManager life;
    GameObject gameManager;
    public int damage = 10;
   
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        life = gameManager.GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            life.ReceiveDamage(damage);
        }
    }
}
