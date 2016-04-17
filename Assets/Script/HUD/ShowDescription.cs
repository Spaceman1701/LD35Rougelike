using UnityEngine;
using System.Collections;

public class SpawnDescription : MonoBehaviour {

	void onGUI()
	{
		Vector3 mouseLocation = Input.mousePosition;
		GUI.Box (new Rect(mouseLocation.x, mouseLocation.y, 20, 20), "This is a test");
	}
}
