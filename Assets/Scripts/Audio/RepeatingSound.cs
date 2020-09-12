using UnityEngine;
using System.Collections;

public class RepeatingSound : MonoBehaviour
{

    public AudioSource audio;
    public AudioClip sound;
    [Range(0.0f, 1.0f)] public float volume;
    public float minInterval, maxInternval;
    private float randomTime;

    void Start()
    {
        Invoke("PlaySound", 0.001f);
        audio.clip = sound;
        audio.volume = volume;
    }
    void PlaySound()
    {
        randomTime = Random.Range(minInterval, maxInternval);
        Invoke("PlaySound", randomTime+sound.length);
        audio.Play();
    }
}