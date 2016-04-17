using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerUnit))]
public class PlayerMovement : MonoBehaviour {
	private const float EPSILON = 0.07f;

	public float speed = 1.5f;
    //public int movImportance;
    public int currImportance;
    private Rigidbody2D playerBody;
    private Vector2 flagLoc;

    //Accessors
    public Vector2 position;
    public Vector2 velocity;
    public float rotation;
    public float angularVelocity;

    private Vector2 waypoint;

    private bool Moving;

    public bool movingToWaypoint = false;

	void Start () 
	{
		flagLoc = transform.position;
        currImportance = 0;
        playerBody = GetComponent<Rigidbody2D>();
	}

	void Update () {
        if (Input.GetButtonDown("right_mouse_button"))
        {
            waypoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = waypoint - new Vector2(transform.position.x, transform.position.y);
            direction.Normalize();
            SetVelocity(direction*speed, 100);
            SetImportance(0);
            movingToWaypoint = true;
            GetComponent<PlayerUnit>().StartMoving();
        } else if (movingToWaypoint)
        {
            Vector2 direction = waypoint - new Vector2(transform.position.x, transform.position.y);
            
            if (direction.magnitude < EPSILON)
            {
                movingToWaypoint = false;
                SetVelocity(new Vector2(0,0), 1);
                GetComponent<PlayerUnit>().EndMoving();
            } else
            {

                direction.Normalize();
                SetVelocity(direction*speed, 0);
                RotateToTarget(direction);
            }
        }

	}

    private void RotateToTarget(Vector2 direction)
    {
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