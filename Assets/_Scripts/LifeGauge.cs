using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{
    public Color color1, color2, color3, color4;
    private Image _HPgauge;
    private float ratio;

    private void Start()
    {
        _HPgauge = this.gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        if(GameManager.instance.pl_Change == true)
        {
            ratio = GameManager.instance.player1Life / GameManager.instance.max_PlayerLife;
        }
        else if(GameManager.instance.pl_Change == false)
        {
            ratio = GameManager.instance.player2Life / GameManager.instance.max_Player2Life;
        }

        if (ratio > 0.75f)
        {
            _HPgauge.color = Color.Lerp(color2, color1, (ratio - 0.75f) * 4f);
        }
        else if (ratio > 0.25f)
        {
            _HPgauge.color = Color.Lerp(color3, color2, (ratio - 0.25f) * 4f);
        }
        else
        {
            _HPgauge.color = Color.Lerp(color4, color3, ratio * 4);
        }
        _HPgauge.fillAmount = ratio;
    }
}
