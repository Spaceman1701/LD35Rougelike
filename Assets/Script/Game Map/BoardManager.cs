using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {
	[Serializable]
	public class Count
	{
		public int maximum;
		public int minimum;

		public Count (int min, int max)
		{
			minimum = min;
			maximum = max;
		}
	}

	public int columns = 50;
	public int rows = 50;


	public Count wallCount = new Count (25, 60);
	public GameObject exit;
	public GameObject[] floorTiles;
	public GameObject[] wallTiles;
	public GameObject[] outerWallTiles;

	private Transform boardHolder;
	private List <Vector3> gridPositions = new List <Vector3> ();

	void InitializeList()
	{
		gridPositions.Clear ();

		for (int x = 0; x < columns - 1; x++) 
		{
			for (int y = 0; y < rows - 1; y++) 
			{
				gridPositions.Add (new Vector3 (x, y, 0f));
			}
		}
	}

	void BoardSetup()
	{
		boardHolder = new GameObject ("Board").transform;

		for (int x = -1; x < columns + 1; x++) 
		{
			for (int y = -1; y < rows + 1; y++) 
			{
				GameObject toInstantiate = floorTiles [Random.Range (0, floorTiles.Length)];
				if (x == -1 || x == columns || y == -1 || y == rows) 
				{
					toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];
				}
					GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), RandomRot()) as GameObject;

					instance.transform.SetParent (boardHolder);
				}
			}
		}

	Vector3 RandomPosition()
	{
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}

	void LayoutObjectAtRandom (GameObject[] tileArray, int minimum, int maximum)
	{
		int objectCount = (columns*rows*Random.Range (5, 15)/100);

		for (int i = 0; i < objectCount; i++) 
		{
			Vector3 randomPosition = RandomPosition ();
			GameObject tileChoice = tileArray [Random.Range (0, tileArray.Length)];
			Instantiate (tileChoice, randomPosition, Quaternion.identity);
		}
	}

    private Quaternion RandomRot()
    {
        Vector3 axis = Vector3.forward;
        Quaternion[] qs = { Quaternion.AngleAxis(90, axis), Quaternion.AngleAxis(180, axis), Quaternion.AngleAxis(270, axis) };

        return qs[Random.Range(0, 3)];
    }

	public void SetupScene (int stage)
	{
		BoardSetup ();
		InitializeList ();
		LayoutObjectAtRandom (wallTiles, wallCount.minimum, wallCount.maximum);
		Instantiate (exit, new Vector3 (columns - 1, rows - 1, 0f), Quaternion.identity);
	}
}
