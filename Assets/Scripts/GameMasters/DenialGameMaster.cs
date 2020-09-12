using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenialGameMaster : MonoBehaviour
{
    public GameObject Tombstone;
    public GameObject Ostrich;
    public GameObject Collar;
    public Sprite OstrichOut;
    public BoxCollider2D OstrichBoxCollider;

    public GameObject collarAndOstrichPhase;
    public PhaseControl phaseControl;

    private Animator collarAnimator;
    private AudioSource collarAudio;
    private SpriteRenderer OstrichRenderer;
    private bool collarAndOstrich;

    void Awake()
    {
        OstrichRenderer = Ostrich.GetComponent<SpriteRenderer>();
        collarAnimator = Collar.GetComponent<Animator>();
        collarAudio = Collar.GetComponent<AudioSource>();
    }

    void Update()
    {
  
    	if(phaseControl.GetCurrentPhase() == collarAndOstrichPhase && collarAndOstrich == false)
    	{
	        OstrichRenderer.sprite = OstrichOut;
	        OstrichBoxCollider.enabled = false;
	        collarAnimator.SetBool("isOpen", true);
	        collarAudio.Play();

	        collarAndOstrich = true;
        }
    }
}
