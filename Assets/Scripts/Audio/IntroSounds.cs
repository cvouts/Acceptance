using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip barkSound;
    [Range(0.0f, 1.0f)] public float barkvolume;
    [SerializeField] private AudioClip whineSound;
    [Range(0.0f, 1.0f)] public float whinevolume;
    [SerializeField] private AudioClip clockSound;
    [Range(0.0f, 1.0f)] public float clockvolume;
    [SerializeField] private AudioClip sobbingSound;
    [Range(0.0f, 1.0f)] public float sobbingvolume;

    void Start()
    {
        
    }

    void Bark()
    {
        if (audio)
        {
            audio.volume = barkvolume;
            audio.PlayOneShot(barkSound);
        }
    }

    void Whine()
    {
        if (audio)
        {
            audio.volume = whinevolume;
            audio.PlayOneShot(whineSound);
        }
    }

    void Clock()
    {
        if (audio)
        {
            audio.volume = clockvolume;
            audio.PlayOneShot(clockSound);
        }
    }

    void Sobb()
    {
        if (audio)
        {
            audio.volume = sobbingvolume;
            audio.PlayOneShot(sobbingSound);
        }
    }
}
