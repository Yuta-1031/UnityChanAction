using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class test : MonoBehaviour
{
    [SerializeField] private PlayableDirector pd;

    // Start is called before the first frame update
    void Start()
    {
        pd.Play();
    }
}
