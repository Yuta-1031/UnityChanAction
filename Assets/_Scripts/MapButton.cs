using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    [SerializeField] GameObject map;
    bool check = false;

    public void Onclick()
    {
        if (!check)
        {
            this.map.SetActive(true);
            this.check = true;
        }
        else if (check)
        {
            this.map.SetActive(false);
            this.check = false;
        }
    }

    private void Update()
    {
        if (!check)
        {
            Time.timeScale = 1.0f;
            //Debug.Log("false");
        }
        else if (check)
        {
            Time.timeScale = 0;
            //Debug.Log("true");
        }
    }
}
