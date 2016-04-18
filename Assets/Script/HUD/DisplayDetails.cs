using UnityEngine;
using System.Collections;

public class DisplayDetails : MonoBehaviour {

	Ability[] abilities;
	int length;

	int abilityIndex = -1;
	public GameObject playerGameObject;

	public int x=0;
	public int y=0;

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

		for (int i = 0; i < length; i++) {
			if (abilities [i].cooldown > 0){
				float cooldownTime = abilities [i].cooldown;
				cooldownTime = Mathf.Round (cooldownTime * 100f) / 100f;
				if (i == 0)
					GUI.Label (new Rect (508, 485, 240, 30), cooldownTime.ToString());
				else if (i == 1)
					GUI.Label (new Rect (590, 485, 240, 30), cooldownTime.ToString());
				else if (i == 2)
					GUI.Label (new Rect (670, 485, 240, 30), cooldownTime.ToString());
				else if (i == 3)
					GUI.Label (new Rect (752, 485, 240, 30), cooldownTime.ToString());
			}
		}
	}
}
