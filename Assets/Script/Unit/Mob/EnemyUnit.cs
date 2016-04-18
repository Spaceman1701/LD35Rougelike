using UnityEngine;
using System.Collections;

public class EnemyUnit : Unit {

	private float speed = 1.5f;

    private PlayerUnit player;
	private Vector2 waypoint;
	public int currImportance;
	private Rigidbody2D enemyBody;

    protected override void OnStart()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerUnit>();
		currImportance = 0;
		enemyBody = GetComponent<Rigidbody2D>();
    }

    protected override void OnUpdate()
    {
        Vector3 playerLoc = player.transform.position;
		waypoint = playerLoc;
		Vector2 direction = waypoint - new Vector2(transform.position.x, transform.position.y);
		direction.Normalize();
		SetVelocity(direction*speed, 100);
		SetImportance(0);
        RotateToTarget((playerLoc - transform.position).normalized);
    }



    private void RotateToTarget(Vector2 direction)
	{
		float dir = 90 + Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
		enemyBody.MoveRotation(dir + 10 * Time.deltaTime);

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
			enemyBody.position = position;
			return true;
		}
		return false;
	}

	public bool SetVelocity (Vector2 velocity, int importance)
	{
		if (importance >= currImportance)
		{
			currImportance = importance;
			enemyBody.velocity = velocity;
			return true;
		}
		return false;
	}

	public bool SetAngle(int angle, int importance)
	{
		if (importance >= currImportance)
		{
			currImportance = importance;
			enemyBody.rotation = angle;
			return true;
		}
		return false;
	}

	public bool SetAngularVelocity(int angvelocity, int importance)
	{
		if (importance >= currImportance)
		{
			currImportance = importance;
			enemyBody.angularVelocity = angvelocity;
			return true;
		}
		return false;
	}


    protected override void OnMoveStart()
    {

    }

    protected override void OnMoveEnd()
    {

    }
    protected override void OnDeath()
    {

    }

}
