using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PhaseCreate : MonoBehaviour
{
    [SerializeField] public GameObject[] phases;

    private int oldNumberOfPhases;
    
    void Update()
    {
    	if(phases.Length == 0)
    	{
    		oldNumberOfPhases = 0;
            Debug.Log("asdf");
    	}

    	//Adding phase gameobject children
    	if(phases.Length > this.transform.childCount)
    	{
    		if(oldNumberOfPhases == 0) //Adding phases for the first time
	    	{
	    		for(int i=0; i < phases.Length; i++)
		    	{	
                    CreatePhaseGameObject(i);
		    		phases[i].transform.parent = this.transform;
		    		phases[i].SetActive(false);

		    		if(i==0)
		    		{
		    			phases[i].SetActive(true);
		    		}
		    	}
	    	}
	    	else //Adding more phases
	    	{
    			for(int i=oldNumberOfPhases; i < phases.Length; i++)
    			{
    				CreatePhaseGameObject(i);
		    		phases[i].transform.parent = this.transform;
		    		phases[i].SetActive(false);
    			}	
	    	}

	    	oldNumberOfPhases = phases.Length;
    	}

    	// if(phases.Length < oldNumberOfPhases)
    	// {
    	// 	for(int i=oldNumberOfPhases; i > phases.Length; i--)
    	// 	{
    	// 		DestroyImmediate(this.gameObject.transform.GetChild(i).gameObject, false);
    	// 	}
    	// }	


        void CreatePhaseGameObject(int i)
        {
            if(i < 10)
            {
                phases[i] = new GameObject("phase0" + i);
            }
            else
            {
                phases[i] = new GameObject("phase" + i);
            }
        }
    }
}
