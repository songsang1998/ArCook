using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PockerAudio : MonoBehaviour
{
    public AudioClip[] bgms;
    // Start is called before the first frame update
   

    // Update is called once per frame
    public void Call()
    {
        GetComponent<AudioSource>().clip = bgms[0];
        GetComponent<AudioSource>().Play();
    }

    public void Rase()
    {
        GetComponent<AudioSource>().clip = bgms[1];
        GetComponent<AudioSource>().Play();
    }

    public void Die()
    {
        GetComponent<AudioSource>().clip = bgms[2];
        GetComponent<AudioSource>().Play();
    }
}
