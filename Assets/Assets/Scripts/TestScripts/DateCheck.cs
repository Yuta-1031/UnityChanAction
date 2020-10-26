using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateCheck : MonoBehaviour
{
    System.DateTime now;
    private int nowMonth;
    private int nowDay;

    public AudioClip voice_aisatu;
    public AudioClip voice_yorosiku;
    public AudioClip voice_0101;
    public AudioClip voice_0115;
    public AudioClip voice_0203;
    public AudioClip voice_0211;
    public AudioClip voice_0214;
    public AudioClip voice_0303;
    public AudioClip voice_0314;
    public AudioClip voice_0319;
    public AudioClip voice_0401;
    public AudioClip voice_0421;
    public AudioClip voice_0422;
    public AudioClip vpice_0503;
    public AudioClip voice_0504;
    public AudioClip voice_0505;
    public AudioClip voice_0602;
    public AudioClip voice_0707;
    public AudioClip voice_0720;
    public AudioClip voice_0813;
    public AudioClip voice_0915;
    public AudioClip voice_0922;
    public AudioClip voice_1008;
    public AudioClip voice_1010;
    public AudioClip voice_1103;
    public AudioClip voice_1123;
    public AudioClip voice_1224;
    public AudioClip voice_1225;
    public AudioClip voice_1231;

    public AudioClip[,] voice_date;
    private AudioSource uniVoice;

    private float delay = 1f;



    // Start is called before the first frame update
    void Start()
    {
        now = System.DateTime.Now;
        nowMonth = now.Month;
        nowDay = now.Day;

        uniVoice = GetComponent<AudioSource>();
        //uniVoice.PlayOneShot(voice_date0101);
        voice_date = new AudioClip[12 + 1, 31 + 1];

        voice_date[1, 1] = voice_0101;
        voice_date[1, 15] = voice_0115;
        voice_date[2, 3] = voice_0203;
        voice_date[2, 11] = voice_0211;
        voice_date[2, 14] = voice_0214;
        voice_date[3, 3] = voice_0303;
        voice_date[3, 14] = voice_0314;
        voice_date[3, 19] = voice_0319;
        voice_date[4, 1] = voice_0401;
        voice_date[4, 21] = voice_0421;
        voice_date[5, 4] = voice_0504;
        voice_date[5, 5] = voice_0505;
        voice_date[6, 2] = voice_0602;
        voice_date[7, 7] = voice_0707;
        voice_date[7, 20] = voice_0720;
        voice_date[8, 13] = voice_0813;
        voice_date[9, 15] = voice_0915;
        voice_date[9, 22] = voice_0922;
        voice_date[10, 8] = voice_1008;
        voice_date[10, 10] = voice_1010;
        voice_date[11, 3] = voice_1103;
        voice_date[11, 23] = voice_1123;
        voice_date[12, 24] = voice_1224;
        voice_date[12, 25] = voice_1225;
        voice_date[12, 31] = voice_1231;

        if (voice_date[nowMonth, nowDay])
        {
            uniVoice.PlayOneShot(voice_date[nowMonth, nowDay]);
        }
        else
        {
            uniVoice.PlayOneShot(voice_aisatu);
            //Invoke("Call", 3f);
        }
    }

    /*void Call()
    {
        uniVoice.PlayOneShot(voice_yorosiku);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
