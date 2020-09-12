using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class DontDestroyOnLoad : MonoBehaviour
{
	//Most of these things are for the audio carrying over on scene change but stopping soon after 
	[SerializeField] private string destroyAfterLoadThisScene;
	public AudioMixer masterMixer;
	
	private bool destroyBegun;
	private static int objectID;
	private float audioMixerVolume;

    void Awake()
    {
    	DontDestroyOnLoad(this.gameObject);
    	destroyBegun = false;

    	//Destroy the duplicate AudioMusic gameobject that spawns when the Denial level is reloaded after entering and exiting the house
    	if(objectID == 0 && this.gameObject.tag == "MusicBetweenScenes")
    	{
    		objectID = this.GetInstanceID();
    	}
    	else if(this.GetInstanceID() != objectID && this.gameObject.tag == "MusicBetweenScenes")
    	{
    		Destroy(this.gameObject);
    	}
    }

    void Update()
    {
    	if(SceneManager.GetActiveScene().name == destroyAfterLoadThisScene && !destroyBegun)
    	{
    		StartCoroutine(AudioController.FadeOut(masterMixer, 15f));
    		masterMixer.GetFloat("MasterVolume", out audioMixerVolume);
    		destroyBegun = true; //this prevents the 'if' statement from being true again
		}

		if(destroyBegun)
		{
			masterMixer.GetFloat("MasterVolume", out audioMixerVolume);

			if(audioMixerVolume <= -10f)
			{
				Destroy(this.gameObject);
			}	
		}
    }
}
