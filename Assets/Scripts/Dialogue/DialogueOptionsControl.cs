using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOptionsControl : MonoBehaviour
{
	public DialogueManager dialogueManager;
	public Dialogue optionDialogue;

	public void OnClickOption()
    {
        dialogueManager.StartDialogue(optionDialogue);
        dialogueManager.isOptionsDialogue = false;
        dialogueManager.option1Button.SetActive(false);
        dialogueManager.option2Button.SetActive(false);
    }
}
