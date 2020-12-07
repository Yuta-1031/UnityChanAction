using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject player;
    public GameObject player2;
    public GameObject icon;
    public float playerLife = 100;
    public float player2Life = 100;

    private bool pl_Change = true;

    private void Awake()
    {
        if(instance == null)
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

        player.SetActive(true);
        player2.SetActive(false);
    }

    private void Update()
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
}
