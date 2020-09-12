using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource buttonsource;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void HoverSound()
    {
        buttonsource.PlayOneShot(hoverSound);
    }
    public void ClickSound()
    {
        buttonsource.PlayOneShot(clickSound);
    }
}
