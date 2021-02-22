using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject icon;
    public float max_PlayerLife = 100;
    public float max_Player2Life = 100;
    public float player1Life;
    public float player2Life;

    [SerializeField] public GameObject player;
    [SerializeField] public GameObject player2;
    [SerializeField] public GameObject cam;

    public bool playerOn;
    public bool pl_Change = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(player);
        DontDestroyOnLoad(player2);
        DontDestroyOnLoad(cam);
        //DontDestroyOnLoad(parent);

        player.SetActive(true);
        player2.SetActive(false);

        player1Life = max_PlayerLife;
        player2Life = max_Player2Life;
    }

    private void Update()
    {
        if (playerOn)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (pl_Change == true)
                {
                    player2.transform.position = player.transform.position;
                    player2.transform.rotation = player.transform.rotation;

                    player.SetActive(false);
                    player2.SetActive(true);

                    pl_Change = false;
                }
                else if (pl_Change == false)
                {
                    player.transform.position = player2.transform.position;
                    player.transform.rotation = player2.transform.rotation;

                    player.SetActive(true);
                    player2.SetActive(false);

                    pl_Change = true;
                }
            }
        }
        else
        {
            player.SetActive(false);
            player2.SetActive(false);
        }
    }

    public void ReceiveDamage(int damage)
    {
        player1Life -= damage;
        //player2Life -= damage;
    }
}
