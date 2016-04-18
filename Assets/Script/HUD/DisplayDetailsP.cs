using UnityEngine;
using System.Collections;

public class DisplayDetailsP : MonoBehaviour {

	public GameObject playerGameObject;

	int showPassive = 0;
	Passive passive;

	void Start()
	{
		passive = playerGameObject.GetComponentInChildren<Passive> ();
	}

	public void showDetails(int show){
		showPassive = show;
	}

	void OnGUI () {
		//Ability descriptions
		if (showPassive == 1) 
		{
			GUI.Label(new Rect(903, 523, 240, 30), passive.Title);
			GUI.Label(new Rect(903, 542, 240, 300), passive.Description);
		}
	}
}
