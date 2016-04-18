﻿using UnityEngine;
using System.Collections;

public class DisplayDetailsP : MonoBehaviour {

	public GameObject playerGameObject;

	int showPassive = 0;
	Passive[] passiveAr;
	Passive passive;

	void Start()
	{
		passiveAr = playerGameObject.GetComponentsInChildren<Passive> ();
		passive = passiveAr [0];
	}

	public void showDetails(int show){
		showPassive = show;
	}

	void OnGUI () {
		//Ability descriptions
		if (showPassive == 1) 
		{
			GUI.Label (new Rect (875, 462, 240, 30), passive.Title);
			GUI.Label (new Rect (875, 480, 240, 300), passive.Description);
		}
	}
}