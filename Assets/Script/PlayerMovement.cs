using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1.5f;
    private int currImportance;
	private Vector3 target;
    private Rigidbody2D playerBody;

    //Accessors
    public Vector2 position;
    public Vector2 velocity;
    public float rotation;
    public float angularVelocity;


    private bool Moving;

	void Start () 
	{
		target = transform.position;
        currImportance = 0;
        playerBody = GetComponent<Rigidbody2D>();
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


    public void SetImportance(int j)
    {
        currImportance = j;
    }

    public bool SetPosition (Vector2 position, int importance)
    {
        if (importance >= currImportance)
        {
            currImportance = importance;
            playerBody.position = position;
            return true;
        }
        return false;
    }

    public bool SetVelocity (Vector2 velocity, int importance)
    {
        if (importance >= currImportance)
        {
            currImportance = importance;
            playerBody.velocity = velocity;
            return true;
        }
        return false;
    }

    public bool SetAngle(int angle, int importance)
    {
        if (importance >= currImportance)
        {
            currImportance = importance;
            playerBody.rotation = angle;
            return true;
        }
        return false;
    }

    public bool SetAngularVelocity(int angvelocity, int importance)
    {
        if (importance >= currImportance)
        {
            currImportance = importance;
            playerBody.angularVelocity = angvelocity;
            return true;
        }
        return false;
    }

    //Accessors
    public Vector2 Position
    {
        get
        {
            return playerBody.position;
        }
    }

    public Vector2 Velocity
    {
        get
        {
            return playerBody.velocity;
        }
    }

    public float Rotation
    {
        get
        {
            return playerBody.rotation;
        }
    }

    public float AngularVelocity
    {
        get
        {
            return playerBody.angularVelocity;
        }
    }



}