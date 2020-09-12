using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshSortingLayer : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    void Start()
    {
    	meshRenderer = GetComponent<MeshRenderer>();
    	meshRenderer.sortingLayerName = "DescriptionTextUI";
    }
}
