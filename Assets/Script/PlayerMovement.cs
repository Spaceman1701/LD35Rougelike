using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1.5f;
	private Vector3 Target;

	private bool Moving;

	void Start () 
	{
		Target = transform.position;
	}

	void Update () {
		if (Input.GetMouseButton(1)) 
		{
			Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Target.z = transform.position.z;
		}
		MoveUnit ();

	}

	void MoveUnit ()
	{
		transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
		Debug.DrawLine (transform.position, Target, Color.red);
	}
}