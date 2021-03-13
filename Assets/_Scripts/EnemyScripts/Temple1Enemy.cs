using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temple1Enemy : MonoBehaviour
{
    [SerializeField] GameObject skeleton1;
    [SerializeField] GameObject skeleton2;

    public Transform sponer1;
    public Transform sponer2;
    public Transform sponer3;
    public Transform sponer4;
    public Transform sponer5;
    public Transform sponer6;

    //public Transform[] sponer;

    bool skel1_IsDisPlay = false;
    bool skel2_IsDisPlay = false;

    bool spone = true;

    private void Start()
    {
        skeleton1.SetActive(false);
        skeleton2.SetActive(false);
    }

    public void Skeleton1SetFalse()
    {
        skel1_IsDisPlay = false;
    }

    public void Skeleton2SetFalse()
    {
        skel2_IsDisPlay = false;
    }

    public void FadeOut1(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            skeleton1.SetActive(false);
            skel1_IsDisPlay = false;
        }
    }

    public void FadeOut2(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            skel2_IsDisPlay = false;
            skeleton2.SetActive(false);
        }
    }

    public void PlayerExit(Collider other)
    {
        spone = true;
    }

    public void EnemySpone(Collider col)
    {
        if(col.gameObject.tag == "Player" && spone)
        {
            spone = false;

            if(!skel1_IsDisPlay && !skel2_IsDisPlay)
            {
                skeleton1.transform.position = sponer1.position;
                skel1_IsDisPlay = true;
                skeleton1.SetActive(true);
            }
            else if(!skel1_IsDisPlay && skel2_IsDisPlay)
            {
                skeleton1.transform.position = sponer1.position;
                skel1_IsDisPlay = true;
                skeleton1.SetActive(true);
            }
            else if(skel1_IsDisPlay && !skel2_IsDisPlay)
            {
                skeleton2.transform.position = sponer1.position;
                skel2_IsDisPlay = true;
                skeleton2.SetActive(true);
            }
            else if(skel1_IsDisPlay && skel2_IsDisPlay)
            {
                return;
            }
            Debug.Log(sponer1.position);
            Debug.Log(skeleton1.transform.position + "S");
        }
    }

    public void EnemySpone2(Collider col)
    {
        if (col.gameObject.tag == "Player" && spone)
        {
            spone = false;

            if (!skel1_IsDisPlay && !skel2_IsDisPlay)
            {
                skeleton1.transform.position = sponer2.position;
                skel1_IsDisPlay = true;
                skeleton1.SetActive(true);
            }
            else if (!skel1_IsDisPlay && skel2_IsDisPlay)
            {
                skeleton1.transform.position = sponer2.position;
                skel1_IsDisPlay = true;
                skeleton1.SetActive(true);
            }
            else if (skel1_IsDisPlay && !skel2_IsDisPlay)
            {
                skeleton2.transform.position = sponer2.position;
                skel2_IsDisPlay = true;
                skeleton2.SetActive(true);
            }
            else if (skel1_IsDisPlay && skel2_IsDisPlay)
            {
                return;
            }
        }
    }

    public void EnemySpone3(Collider col)
    {
        if (col.gameObject.tag == "Player" && spone)
        {
            spone = false;

            if (!skel1_IsDisPlay && !skel2_IsDisPlay)
            {
                skeleton1.transform.position = sponer3.position;
                skel1_IsDisPlay = true;
                skeleton1.SetActive(true);
            }
            else if (!skel1_IsDisPlay && skel2_IsDisPlay)
            {
                skeleton1.transform.position = sponer3.position;
                skel1_IsDisPlay = true;
                skeleton1.SetActive(true);
            }
            else if (skel1_IsDisPlay && !skel2_IsDisPlay)
            {
                skeleton2.transform.position = sponer3.position;
                skel2_IsDisPlay = true;
                skeleton2.SetActive(true);
            }
            else if (skel1_IsDisPlay && skel2_IsDisPlay)
            {
                return;
            }
        }
    }

    public void EnemySpone4(Collider col)
    {
        if (col.gameObject.tag == "Player" && spone)
        {
            spone = false;

            if (!skel1_IsDisPlay && !skel2_IsDisPlay)
            {
                skeleton1.transform.position = sponer4.localPosition;
                skel1_IsDisPlay = true;
                skeleton1.SetActive(true);
            }
            else if (!skel1_IsDisPlay && skel2_IsDisPlay)
            {
                skeleton1.transform.position = sponer4.localPosition;
                skel1_IsDisPlay = true;
                skeleton1.SetActive(true);
            }
            else if (skel1_IsDisPlay && !skel2_IsDisPlay)
            {
                skeleton2.transform.position = sponer4.localPosition;
                skel2_IsDisPlay = true;
                skeleton2.SetActive(true);
            }
            else if (skel1_IsDisPlay && skel2_IsDisPlay)
            {
                return;
            }
        }
    }

    public void EnemySpone5(Collider col)
    {
        if (col.gameObject.tag == "Player" && spone)
        {
            spone = false;

            if (!skel1_IsDisPlay && !skel2_IsDisPlay)
            {
                skeleton1.transform.position = sponer5.position;
                skel1_IsDisPlay = true;
                skeleton1.SetActive(true);
            }
            else if (!skel1_IsDisPlay && skel2_IsDisPlay)
            {
                skeleton1.transform.position = sponer5.position;
                skel1_IsDisPlay = true;
                skeleton1.SetActive(true);
            }
            else if (skel1_IsDisPlay && !skel2_IsDisPlay)
            {
                skeleton2.transform.position = sponer5.position;
                skel2_IsDisPlay = true;
                skeleton2.SetActive(true);
            }
            else if (skel1_IsDisPlay && skel2_IsDisPlay)
            {
                return;
            }
        }
    }

    public void EnemySpone6(Collider col)
    {
        if (col.gameObject.tag == "Player" && spone)
        {
            spone = false;

            if (!skel1_IsDisPlay && !skel2_IsDisPlay)
            {
                skeleton1.transform.position = sponer6.position;
                skel1_IsDisPlay = true;
                skeleton1.SetActive(true);
            }
            else if (!skel1_IsDisPlay && skel2_IsDisPlay)
            {
                skeleton1.transform.position = sponer6.position;
                skel1_IsDisPlay = true;
                skeleton1.SetActive(true);
            }
            else if (skel1_IsDisPlay && !skel2_IsDisPlay)
            {
                skeleton2.transform.position = sponer6.position;
                skel2_IsDisPlay = true;
                skeleton2.SetActive(true);
            }
            else if (skel1_IsDisPlay && skel2_IsDisPlay)
            {
                return;
            }
        }
    }

    private void Update()
    {
       // Debug.Log(skel1_IsDisPlay);
       // Debug.Log(skel2_IsDisPlay);
    }
}
