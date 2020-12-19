using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempleSceneChange : MonoBehaviour
{
   // public GameObject parentOff;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //parentOff.transform.parent = null;

            //SceneManager.LoadScene("GameScene");
        }
    }
}
