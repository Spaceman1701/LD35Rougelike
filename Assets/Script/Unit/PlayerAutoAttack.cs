using UnityEngine;
using System.Collections;
using System;

public class PlayerAutoAttack : AutoAttack {

    private Unit autoFollowTarget;

    public void Update()
    {
        Rigidbody2D body = GetComponentInChildren<Rigidbody2D>();
        
        if (body.velocity.magnitude > 0 || body.angularVelocity > 0)
        {
            CancelAuto();
        }
        if (autoFollowTarget != null)
        {
            FollowAutoTarget();
        }
    }

    internal void AttemptAuto(Unit u)
    {
        if (InAutoRange(u))
        {
            StartAuto(u);
            return;
        }

        autoFollowTarget = u;
    }

    private void FollowAutoTarget()
    {
        Vector2 direction = new Vector2(autoFollowTarget.transform.position.x, autoFollowTarget.transform.position.y)
            - new Vector2(transform.position.x, transform.position.y);
        direction.Normalize();
        PlayerMovement pm = GetComponent<PlayerMovement>();
        pm.SetVelocity(direction * pm.speed, 0);
        pm.RotateToTarget(direction);
    }

    public void CancelFollow()
    {
        autoFollowTarget = null;
    }
}
