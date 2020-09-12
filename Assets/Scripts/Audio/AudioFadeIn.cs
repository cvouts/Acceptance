using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioFadeIn : MonoBehaviour
{
    public AudioMixer masterMixer;
    private bool alreadyFadedInOnce;

    void Start()
    {
    	if(alreadyFadedInOnce == false)
    	{
    		StartCoroutine(AudioController.FadeIn(masterMixer, 5f));
    		alreadyFadedInOnce = true;	
    	}
        
    }
}
