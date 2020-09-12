using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class AudioController
{
    public static IEnumerator FadeOut(AudioMixer audioMixer, float FadeTime)
    {
        float volume;
        audioMixer.GetFloat("MasterVolume", out volume);
        while (volume > -80f)
        {
            volume -= Mathf.Abs(Mathf.Log(80 / (FadeTime / (10*Time.deltaTime))));
            audioMixer.SetFloat("MasterVolume",volume);
            //Debug.Log(volume);
            yield return null;
        }
    }

    public static IEnumerator FadeIn(AudioMixer audioMixer, float FadeTime)
    {
        float volume = -80f;
        audioMixer.SetFloat("MasterVolume", volume);
        while (volume < 0)
        {
            volume += Mathf.Abs(Mathf.Log(80 / (FadeTime / (10 * Time.deltaTime))));
            audioMixer.SetFloat("MasterVolume", volume);
            yield return null;
        }
    }
}
