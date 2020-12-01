using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GateOpen : MonoBehaviour
{
    [SerializeField] private PlayableDirector pd;

    // Start is called before the first frame update
    void Start()
    {
        //this.pd = GetComponent<PlayableDirector>();
    }

    public void OpenTimeLine()
    {
        pd.Play();
    }
}
