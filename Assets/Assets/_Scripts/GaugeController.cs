using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    private Image redGauge;
    private Image yellowGauge;
    private Image greenGauge;
    private Image gauge;
    private Image icon1;
    private Image icon2;
    private Image icon3;
    private Image icon4;
    private float fill = 0.75f;
    private float maxLife;
    private float maxLimit = 250f;
    

    // Start is called before the first frame update
    void Start()
    {
        this.gauge = transform.Find("Gauge").GetComponent<Image>();
        this.redGauge = transform.Find("RedGauge").GetComponent<Image>();
        this.greenGauge = transform.Find("GreenGauge").GetComponent<Image>();
        this.yellowGauge = transform.Find("YellowGauge").GetComponent<Image>();
        this.icon1 = transform.Find("Image1").GetComponent<Image>();
        this.icon2 = transform.Find("Image2").GetComponent<Image>();
        this.icon3 = transform.Find("Image3").GetComponent<Image>();
        this.icon4 = transform.Find("Image4").GetComponent<Image>();
        gauge.fillAmount = 0.75f;
        this.maxLife = GameManager.instance.playerLife;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(greenGauge.fillAmount);

        if(GameManager.instance.playerLife == maxLife)
        {
            icon1.gameObject.SetActive(true);
            icon2.gameObject.SetActive(false);
            icon3.gameObject.SetActive(false);
            icon4.gameObject.SetActive(false);

            greenGauge.gameObject.SetActive(true);
            yellowGauge.gameObject.SetActive(false);
            redGauge.gameObject.SetActive(false);
        }
        if(GameManager.instance.playerLife >= maxLife / 2 && GameManager.instance.playerLife < maxLife)
        {
            icon1.gameObject.SetActive(false);
            icon2.gameObject.SetActive(true);
            icon3.gameObject.SetActive(false);
            icon4.gameObject.SetActive(false);

            greenGauge.gameObject.SetActive(true);
            yellowGauge.gameObject.SetActive(false);
            redGauge.gameObject.SetActive(false);
            greenGauge.fillAmount = GameManager.instance.playerLife / maxLife * fill;
        }
        else if(GameManager.instance.playerLife < maxLife / 2 && GameManager.instance.playerLife >= maxLife / 4)
        {
            icon1.gameObject.SetActive(false);
            icon2.gameObject.SetActive(false);
            icon3.gameObject.SetActive(true);
            icon4.gameObject.SetActive(false);

            greenGauge.gameObject.SetActive(false);
            yellowGauge.gameObject.SetActive(true);
            redGauge.gameObject.SetActive(false);
            yellowGauge.fillAmount = GameManager.instance.playerLife / maxLife * fill;
        }
        else if (GameManager.instance.playerLife < maxLife / 4)
        {
            icon1.gameObject.SetActive(false);
            icon2.gameObject.SetActive(false);
            icon3.gameObject.SetActive(false);
            icon4.gameObject.SetActive(true);

            greenGauge.gameObject.SetActive(false);
            yellowGauge.gameObject.SetActive(false);
            redGauge.gameObject.SetActive(true);
            redGauge.fillAmount = GameManager.instance.playerLife / maxLife * fill;
        }
    }
}
