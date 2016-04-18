using UnityEngine;
using System.Collections;

public class DisplayDetails : MonoBehaviour {

	Ability[] abilities;
	int length;

	int abilityIndex = -1;
	public GameObject playerGameObject;

	void Start()
	{
		abilities = playerGameObject.GetComponentsInChildren<Ability> ();
		length = abilities.Length;
	}

	public void showDetails(int index){
		abilityIndex = index;
	}

	void OnGUI () {
		length = abilities.Length;
		//Ability descriptions
		if (abilityIndex == 0 && abilityIndex < length) 
		{
			string abilityDesc = abilities [abilityIndex].Description;
			string abilityTitle = abilities [abilityIndex].Title;

			GUI.Label (new Rect (875, 462, 240, 30), abilityTitle);
			GUI.Label (new Rect (875, 480, 240, 300), abilityDesc);
		}
		else if (abilityIndex == 1 && abilityIndex < length) 
		{
			string abilityDesc = abilities [abilityIndex].Description;
			string abilityTitle = abilities [abilityIndex].Title;

			GUI.Label (new Rect (875, 462, 240, 30), abilityTitle);
			GUI.Label (new Rect (875, 480, 240, 300), abilityDesc);
		}
		else if (abilityIndex == 2 && abilityIndex < length) 
		{
			string abilityDesc = abilities [abilityIndex].Description;
			string abilityTitle = abilities [abilityIndex].Title;

			GUI.Label (new Rect (875, 462, 240, 30), abilityTitle);
			GUI.Label (new Rect (875, 480, 240, 300), abilityDesc);
		}
		else if (abilityIndex == 3 && abilityIndex < length) 
		{
			string abilityDesc = abilities [abilityIndex].Description;
			string abilityTitle = abilities [abilityIndex].Title;

			GUI.Label (new Rect (875, 462, 240, 30), abilityTitle);
			GUI.Label (new Rect (875, 480, 240, 300), abilityDesc);
		}
	}
}
