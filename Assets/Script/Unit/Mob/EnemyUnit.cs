using UnityEngine;
using System.Collections;

public class EnemyUnit : Unit {

    private PlayerUnit player;

    protected override void OnStart()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerUnit>();
    }

    protected override void OnUpdate()
    {
        Vector3 playerLoc = player.transform.position;

        RotateToTarget((transform.position - playerLoc).normalized);
    }

    private void RotateToTarget(Vector2 direction)
    {
        float dir = 90 + Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
        GetComponent<Rigidbody2D>().MoveRotation(dir + 10 * Time.deltaTime);

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
