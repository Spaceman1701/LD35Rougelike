using UnityEngine;
using System.Collections;

public class GameManagerTemp : MonoBehaviour {

	public static GameManagerTemp instance = null;
	public BoardManager boardScript;

	private int level = 50;

	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent<BoardManager> ();
		InitGame ();
	}

	void InitGame()
	{
		boardScript.SetupScene(level);
	}
}
