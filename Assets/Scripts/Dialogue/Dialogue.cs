using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
	public GameObject phaseRequired;
	public bool isStatic;

	[HideInInspector] public int phaseNumber;

    [TextArea(3, 10)]
    public string[] sentences;
}
