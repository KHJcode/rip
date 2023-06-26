using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEndingSound : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
        this.audioSource.Play();
    }
}
