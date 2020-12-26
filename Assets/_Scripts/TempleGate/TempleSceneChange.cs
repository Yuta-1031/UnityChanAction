using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempleSceneChange : MonoBehaviour
{
   public GameObject Per_h;

    private void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene("GameScene");
            SceneManager.LoadScene("TempleSummit");
        }
    }
}
