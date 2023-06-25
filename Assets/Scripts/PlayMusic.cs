using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioClip afternoonMusicClip;
    public AudioClip nightMusicClip;
    public Environment environment;
    AudioSource audioSource;

    private void Awake()
    {
        this.environment.registrationAfternoonHandler(this.changeMusicToAfternoonVersion);
        this.environment.registrationNightHandler(this.changeMusicToNightVersion);
        this.audioSource = GetComponent<AudioSource>();
    }

    private void changeMusicToNightVersion()
    {
        this.audioSource.clip = this.nightMusicClip;
        this.audioSource.Play();
    }

    private void changeMusicToAfternoonVersion()
    {
        this.audioSource.clip = this.afternoonMusicClip;
        this.audioSource.Play();
    }
}
