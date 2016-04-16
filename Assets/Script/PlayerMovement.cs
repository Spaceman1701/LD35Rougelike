using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1.5f;
    public int movImportance;
    private int currImportance;
    private Rigidbody2D playerBody;
    private Vector2 flagLoc;

    //Accessors
    public Vector2 position;
    public Vector2 velocity;
    public float rotation;
    public float angularVelocity;


    private bool Moving;

	void Start () 
	{
		flagLoc = transform.position;
        currImportance = 0;
        playerBody = GetComponent<Rigidbody2D>();
	}

	void Update () {
		if (Input.GetMouseButton(1)) 
		{
			flagLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
        RotateToTarget(flagLoc);
		MoveUnit ();

	}

	void MoveUnit ()
	{
		if(movImportance > currImportance)
        {

        }
	}

    private void RotateToTarget(Vector2 flagLoc)
    {
        
        Vector2 direction = flagLoc - playerBody.position;
        

        float dir = 90 + Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        playerBody.MoveRotation(dir + 10 * Time.deltaTime);
        
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