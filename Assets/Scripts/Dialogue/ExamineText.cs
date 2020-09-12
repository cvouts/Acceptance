using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineText : MonoBehaviour
{
    
	public Transform text;
	public static string textstatus = "off";

	//on Collision Enter
	public void TextAppear()
	{
		text.GetComponent<TextMesh>().text = "asdf";
		textstatus = "on";
		Instantiate(text, new Vector2(transform.position.x, transform.position.y), transform.rotation);
	}

	public void TextDissapear()
	{
		textstatus = "off";
	}

   
}
