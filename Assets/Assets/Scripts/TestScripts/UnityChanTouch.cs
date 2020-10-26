using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanTouch : MonoBehaviour
{
    private Animator anim;
    private AudioSource uniVoice;
    public AudioClip voice_1;
    public AudioClip voice_2;
    public AudioClip voice_3;
    public AudioClip voice_4;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        uniVoice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Touch", false);
        anim.SetBool("Touch_1", false);
        anim.SetBool("Touch_2", false);
        anim.SetBool("Touch_3", false);

        Ray ray;
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                //Debug.Log("hit");
                int nom = Random.Range(1, 5);
                if(nom == 1)
                {
                    anim.SetBool("Touch", true);
                    uniVoice.clip = voice_1;
                    uniVoice.Play();
                }
                else if(nom == 2)
                {
                    anim.SetBool("Touch_1", true);
                    uniVoice.clip = voice_2;
                    uniVoice.Play();
                }
                else if(nom == 3)
                {
                    anim.SetBool("Touch_2", true);
                    uniVoice.clip = voice_3;
                    uniVoice.Play();
                }
                else if(nom == 4)
                {
                    anim.SetBool("Touch_3", true);
                    uniVoice.clip = voice_4;
                    uniVoice.Play();
                }
            }
        }
    }
}
