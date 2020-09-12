using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public PhaseControl phaseControl;
    public GameObject character;
    public DialogueManager dialogueManager;
    public Dialogue dialogue;
    [HideInInspector] public bool staticDialogueTrigger;

    private Animator animatorPlayer;

    public void Start()
    {
        animatorPlayer = character.GetComponent<Animator>();
        staticDialogueTrigger = dialogue.isStatic;

        dialogue.phaseNumber = System.Convert.ToInt32(dialogue.phaseRequired.name.Substring(5,2));
    }

    public bool TriggerDialogue()
    {
    	if(CanTriggerDialogue())
    	{
    		animatorPlayer.SetBool("examine", true);
    		dialogueManager.StartDialogue(dialogue);
    		return true;
    	}

    	return false;
    }

    public bool FinishDialogue()
    {
    	if(dialogueManager.getEnd())
    	{
    		animatorPlayer.SetBool("examine", false);
            return true;
        }
        return false;
    }

    public bool CanTriggerDialogue()
    {
        if(dialogue.phaseRequired == null)
        {
            Debug.Log("need to specify a required phase in the inspector of the relevant Discussion");
        }

        if(!dialogue.isStatic && phaseControl.GetCurrentPhase() == dialogue.phaseRequired) //Trigger an actual dialogue
        {
            return true;
        }
        else if(dialogue.isStatic && (phaseControl.GetCurrentPhaseNumber() >= dialogue.phaseNumber)) //Trigger the static dialogue
        {
        	return true;
        }

        return false;
    }
}
