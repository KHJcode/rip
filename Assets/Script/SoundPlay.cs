using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    public AudioClip afternoonMusicClip;
    public AudioClip nightMusicClip;
    public Environment environment;
    AudioSource audioSource;

    private void Awake()
    {
        this.environment.registrationAfternoonHandler(changeMusicToAfternoonVersion);
        this.environment.registrationNightHandler(changeMusicToNightVersion);
        this.audioSource = GetComponent<AudioSource>();
    }

    public void changeMusicToNightVersion()
    {
        this.audioSource.clip = this.nightMusicClip;
        this.audioSource.Play();
    }

    public void changeMusicToAfternoonVersion()
    {
        this.audioSource.clip = this.afternoonMusicClip;
        this.audioSource.Play();
    }
}
