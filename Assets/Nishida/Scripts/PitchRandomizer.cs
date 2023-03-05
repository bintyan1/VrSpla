using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchRandomizer : MonoBehaviour
{
    private AudioSource[] audios;
    public float max, min;
    void Start()
    {
        audios = GetComponents<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.pitch = Random.Range(max, min);
        }
        //GetComponent<AudioSource>().pitch = Random.Range(max, min);
    }
}
