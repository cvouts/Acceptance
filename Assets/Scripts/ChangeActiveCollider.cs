using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeActiveCollider : MonoBehaviour
{
  	public PhaseControl phaseControl;
    public GameObject phaseRequired;

    public Collider2D oldCollider;
    public Collider2D newCollider;

    private bool changeHappened;

    void Update ()
    {
    	if(phaseControl.GetCurrentPhase() == phaseRequired && changeHappened == false)
    	{
    		oldCollider.enabled = !oldCollider.enabled;
    		newCollider.enabled = !newCollider.enabled;
    		changeHappened = true;
    	}
    }
}
