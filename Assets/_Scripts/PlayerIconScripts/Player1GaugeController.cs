using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1GaugeController : MonoBehaviour
{
    [SerializeField] private Image icon1;
    [SerializeField] private Image icon2;
    [SerializeField] private Image icon3;
    [SerializeField] private Image icon4;
    [SerializeField] private Image icon5;
    [SerializeField] private Image icon6;
    [SerializeField] private Image icon7;
    [SerializeField] private Image icon8;
    private float maxLife;
    private float p2_maxLife;

    void Start()
    {
        this.maxLife = GameManager.instance.max_PlayerLife;
        this.p2_maxLife = GameManager.instance.max_Player2Life;
    }
    void Update()
    {
//        Debug.Log(GameManager.instance.pl_Change);
        if (!GameManager.instance.pl_Change)
        {
            icon1.gameObject.SetActive(false);
            icon2.gameObject.SetActive(false);
            icon3.gameObject.SetActive(false);
            icon4.gameObject.SetActive(false);

            if (GameManager.instance.player2Life == p2_maxLife)
            {
                icon5.gameObject.SetActive(true);
                icon6.gameObject.SetActive(false);
                icon7.gameObject.SetActive(false);
                icon8.gameObject.SetActive(false);
            }
            if (GameManager.instance.player2Life >= p2_maxLife / 2 && GameManager.instance.player2Life < p2_maxLife)
            {
                icon5.gameObject.SetActive(false);
                icon6.gameObject.SetActive(true);
                icon7.gameObject.SetActive(false);
                icon8.gameObject.SetActive(false);
            }
            else if (GameManager.instance.player2Life < p2_maxLife / 2 && GameManager.instance.player2Life >= p2_maxLife / 4)
            {
                icon5.gameObject.SetActive(false);
                icon6.gameObject.SetActive(false);
                icon7.gameObject.SetActive(true);
                icon8.gameObject.SetActive(false);
            }
            else if (GameManager.instance.player2Life < p2_maxLife / 4)
            {
                icon5.gameObject.SetActive(false);
                icon6.gameObject.SetActive(false);
                icon7.gameObject.SetActive(false);
                icon8.gameObject.SetActive(true);
            }
        }
        else
        {
            icon5.gameObject.SetActive(false);
            icon6.gameObject.SetActive(false);
            icon7.gameObject.SetActive(false);
            icon8.gameObject.SetActive(false);

            if (GameManager.instance.player1Life == maxLife)
            {
                icon1.gameObject.SetActive(true);
                icon2.gameObject.SetActive(false);
                icon3.gameObject.SetActive(false);
                icon4.gameObject.SetActive(false);
            }
            if (GameManager.instance.player1Life >= maxLife / 2 && GameManager.instance.player1Life < maxLife)
            {
                icon1.gameObject.SetActive(false);
                icon2.gameObject.SetActive(true);
                icon3.gameObject.SetActive(false);
                icon4.gameObject.SetActive(false);
            }
            else if (GameManager.instance.player1Life < maxLife / 2 && GameManager.instance.player1Life >= maxLife / 4)
            {
                icon1.gameObject.SetActive(false);
                icon2.gameObject.SetActive(false);
                icon3.gameObject.SetActive(true);
                icon4.gameObject.SetActive(false);
            }
            else if (GameManager.instance.player1Life < maxLife / 4)
            {
                icon1.gameObject.SetActive(false);
                icon2.gameObject.SetActive(false);
                icon3.gameObject.SetActive(false);
                icon4.gameObject.SetActive(true);
            }
        }
    }
}
