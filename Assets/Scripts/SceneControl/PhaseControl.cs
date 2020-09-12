using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PhaseControl
{
  private GameObject currentPhase;
  private GameObject oldPhase;
  private string phaseNumberString;
  private int phaseNumber;

  private GameObject phaseParentObject;

  public GameObject GetCurrentPhase()
  {
    phaseParentObject = GameObject.Find("Phases");

    for (int i = 0; i < phaseParentObject.transform.childCount; i++)
    {
      if(phaseParentObject.transform.GetChild(i).gameObject.activeSelf == true)
      {
        currentPhase = phaseParentObject.transform.GetChild(i).gameObject;
        break;
      }
    }
    return currentPhase;
  }

  //Called for the static dialogue
  public int GetCurrentPhaseNumber()
  {
    phaseNumberString = GetCurrentPhase().name.Substring(5,2);
    phaseNumber = System.Convert.ToInt32(phaseNumberString);

    return phaseNumber;
  }

  public GameObject SetCurrentPhase()
  {
    phaseParentObject = GameObject.Find("Phases");

    for (int i = 0; i < phaseParentObject.transform.childCount-1; i++)
    {
      if(phaseParentObject.transform.GetChild(i).gameObject.activeSelf == true)
      {
        oldPhase = phaseParentObject.transform.GetChild(i).gameObject;
        currentPhase = phaseParentObject.transform.GetChild(i+1).gameObject;
        currentPhase.SetActive(true);
        oldPhase.SetActive(false);
        break;
      }
    }
    return currentPhase;
  }

}
