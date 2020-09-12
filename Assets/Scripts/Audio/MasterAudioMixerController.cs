using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MasterAudioMixerController : MonoBehaviour
{
    public AudioMixer[] audiomixer;

    public void SetMusicVol(float musicvol)
    {
        for(int i = 0; i < audiomixer.Length;i++)
        {
            audiomixer[i].SetFloat("musicvol", Mathf.Log10(musicvol)*20);
        }
        
    }

    public void SetSFXVol(float sfxvol)
    {
        for (int i = 0; i < audiomixer.Length; i++)
        {
            audiomixer[i].SetFloat("sfxvol", Mathf.Log10(sfxvol) * 20);
        }

    }
}
