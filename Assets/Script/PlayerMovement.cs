using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1.5f;
	private Vector3 target;

	private bool Moving;

	void Start () 
	{
		target = transform.position;
	}

	void Update () {
		if (Input.GetMouseButton(1)) 
		{
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
		}
        RotateToTarget(target);
		MoveUnit ();

	}

	void MoveUnit ()
	{
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
		Debug.DrawLine (transform.position, target, Color.red);
	}

    private void RotateToTarget(Vector3 target)
    {
        Vector3 direction = target - transform.position;
        direction.Normalize();

        float dir = Mathf.Atan2(direction.y, direction.x);

        transform.rotation = Quaternion.AngleAxis(dir*Mathf.Rad2Deg + 90, Vector3.forward);
    }
}