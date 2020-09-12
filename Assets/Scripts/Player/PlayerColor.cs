using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public Color playerColor;

    public SpriteRenderer leftarm, rightarm, leftleg, rightleg, torso, head, eye;
    void Start()
    {
        leftarm.color = playerColor;
        rightarm.color = playerColor;
        leftleg.color = playerColor;
        rightleg.color = playerColor;
        torso.color = playerColor;
        eye.color = playerColor;
        head.color = playerColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
