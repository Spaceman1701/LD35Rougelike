using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public void ChangeToScene(int scene){
		Application.LoadLevel (scene);
	}
}
