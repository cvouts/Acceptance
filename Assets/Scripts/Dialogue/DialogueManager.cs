using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public float typingSpeed;
    public GameObject continueButton, option1Button, option2Button;
    public GameObject player;
    public Animator animator;
        
    public bool isOptionsDialogue;

    public PhaseControl phaseControl;
    private GameObject currentPhase;

    private Queue<string> sentences;
    private PlayerPlatformerController playerController;
    private string sentence;
    private bool end;
    private Dialogue thisDialogue;

    private int gettingToDeveloperInstantText;
    private bool developerInstantText;

    void Awake()
    {
        continueButton.SetActive(false);
        if(isOptionsDialogue)
        {
            option1Button.SetActive(false);
            option2Button.SetActive(false);
        }

        sentences = new Queue<string>();
        playerController = player.GetComponent<PlayerPlatformerController>();

        currentPhase = phaseControl.GetCurrentPhase();
    }

    private void Update()
    {
        if (textDisplay.text == sentence) 
        {
            if(isOptionsDialogue && sentences.Count == 0)
            {
                option1Button.SetActive(true);
                option2Button.SetActive(true);
            }
            else
            {
                continueButton.SetActive(true);
            }
        }

        //If Space is pressed and we are not in a situation where the player has to choose an option, display next sentence
        if (Input.GetButtonDown("Jump") && textDisplay.text == sentence && ( !isOptionsDialogue || ( isOptionsDialogue && (sentences.Count != 0)))) 
        {
            DisplayNextSentence();
        }

        if(Input.GetButtonDown("Fire1"))
        {
            gettingToDeveloperInstantText++;
        }

        if(gettingToDeveloperInstantText >= 3)
        {
            if(!developerInstantText) //Enable developer instant text
            {
                developerInstantText = true;
                gettingToDeveloperInstantText = 0;
                Debug.Log("DEVELOPERS DO NOT WAIT");
            }
            else if(developerInstantText) //Disable developer instant text
            {
                developerInstantText = false;
                gettingToDeveloperInstantText = 0;
                Debug.Log("WEAK");
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        FlipPlayerIfNeeded();

        thisDialogue = dialogue;
        end = false ;
        playerController.setMovementDisable(true);
        textDisplay.text = "";
        animator.SetBool("isOpen", true);
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(Type());
    }

    IEnumerator Type() 
    {
        continueButton.SetActive(false);
        textDisplay.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            textDisplay.text += letter;
            if(!developerInstantText)
            {
                yield return new WaitForSeconds(typingSpeed);
            }
            else
            {
                textDisplay.text = sentence;
                yield return null;
            }
        }
    }

    void EndDialogue()
    {
        end = true;
        textDisplay.text = "";
        if(isOptionsDialogue)
        {
            option1Button.SetActive(false);
            option2Button.SetActive(false);
        }
        else
        {
            continueButton.SetActive(false);
            animator.SetBool("isOpen", false);
            playerController.setMovementDisable(false);
        }
        
        //Only advance the phase if the dialogue in progress is not a static dialogue
        if(!thisDialogue.isStatic)
        {
            currentPhase = phaseControl.SetCurrentPhase();
        }
    }

    public bool getEnd() 
    {
        bool tmp = end;
        end = false;
        return tmp;
    }

    //This makes sure that the player is always facing the object or person he is interacting with 
    private void FlipPlayerIfNeeded()
    {
         if(this.transform.parent.parent.transform.position.x < player.transform.position.x && playerController.isFacingRight)
         {
            playerController.Flip();
         }
         else if(this.transform.parent.parent.transform.position.x > player.transform.position.x && !playerController.isFacingRight)
         {
            playerController.Flip();
         }
    }
}
