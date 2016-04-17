using UnityEngine;
using System.Collections;

public class ShowDescription : MonoBehaviour {

	public bool boolMouseOver = false ;
	void OnMouseOver() // This Function for  Mouse Over a Mesh or GUIContent
	{
		boolMouseOver = true;
	}
	void OnMouseExit() // This Function for  Mouse Not Over a Mesh or GUIContent
	{
		boolMouseOver = false;
	}
	void OnGUI()
	{
		GUI.depth = -10;

		GUI.Button(new Rect(10, 10, 100, 20), new GUIContent("Click me", "Mouse Over Button")); // When Mouse Over this button GUI.tooltip = "Mouse Over Button"


		if(GUI.tooltip =="Mouse Over Button")
		{
			boolMouseOver = true;
		}
		else
		{
			boolMouseOver = false;
		}

		if (boolMouseOver == true) {
			GUI.Box (new Rect (500, 100, 100, 50), "Here is a box");

			GUI.Box (new Rect (100, 100, 100, 50), "Here is a Button");
		}
	
	}
}