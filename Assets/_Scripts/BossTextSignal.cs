using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTextSignal : MonoBehaviour
{
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;

    BrunoMikoski.TextJuicer.JuicedText text1Script;
    BrunoMikoski.TextJuicer.JuicedText text2Script;

    private void Start()
    {
        text1Script = text1.GetComponent<BrunoMikoski.TextJuicer.JuicedText>();
        text2Script = text2.GetComponent<BrunoMikoski.TextJuicer.JuicedText>();
    }
    public void TextOn()
    {
        text1Script.enabled = true;
        text2Script.enabled = true;
    }
}
