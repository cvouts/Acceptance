using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExamineTrigger : MonoBehaviour
{  
    public GameObject character;
    public Animator descriptionAnimator;
    public PhaseControl phaseControl;
    public DialogueTrigger staticDialogueTrigger;
    [SerializeField] public DialogueTrigger[] dialogueTrigger;

    private PlayerPlatformerController controller; 
    private int index = 0;
    private bool disableExamine;
    private bool canShowDescription;

    void Awake()
    {
        controller = character.GetComponent<PlayerPlatformerController>();
    }

    void OnTriggerEnter2D()
	{ 
        if(dialogueTrigger[0].CanTriggerDialogue() || canShowDescription)
        {
            descriptionAnimator.SetBool("isOpen", true);
            canShowDescription = true;
        }    
    }

    void OnTriggerStay2D()
    {
        if (controller.examine && index < dialogueTrigger.Length && !disableExamine) //Trigger actual dialogue
        {
            if(dialogueTrigger[index].TriggerDialogue())
            {
            	descriptionAnimator.SetBool("isOpen", false);
            	disableExamine = true; //So that if the player presses E during the dialogue it does not reset
            }
        	else //If the next dialogue cannot be triggered, trigger the static dialogue
        	{
        		staticDialogueTrigger.TriggerDialogue();
        		descriptionAnimator.SetBool("isOpen", false);
            	disableExamine = true;
        	}
        }

        if(dialogueTrigger[index].FinishDialogue() && index < dialogueTrigger.Length -1)
        {
            index++;
        }
    }
    
    void OnTriggerExit2D()
    {
        disableExamine = false; //So that the player can re-examine an interactable upon trigger re-entry
        descriptionAnimator.SetBool("isOpen", false); 
    }
}
