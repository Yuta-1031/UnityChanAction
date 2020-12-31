using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTaxtTest : MonoBehaviour
{
    BrunoMikoski.TextJuicer.JuicedText script;

    void Start()
    {
        script = GetComponent<BrunoMikoski.TextJuicer.JuicedText>();

        Invoke("textOn", 2f);
    }

    void textOn()
    {
        script.enabled = true;
    }
}
