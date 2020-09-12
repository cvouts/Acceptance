using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeDescriptionName : MonoBehaviour
{
   	public PhaseControl phaseControl;
   	public string originalDescriptionName; 
	public string newDescriptionName;
	public GameObject phaseRequired;

	private bool nameChanged;

	void Start()
	{
		GetComponent<TextMesh>().text = originalDescriptionName;
	}

	void Update()
	{
		if(phaseControl.GetCurrentPhase() == phaseRequired && nameChanged == false)
		{
			GetComponent<TextMesh>().text = newDescriptionName;
			nameChanged = true;
		}
	}

}
