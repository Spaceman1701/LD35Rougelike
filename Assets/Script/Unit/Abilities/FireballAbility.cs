using UnityEngine;
using System.Collections;
using System;

public class FireballAbility : Ability
{
    public GameObject fireball;
    public override void OnCast()
    {
        if (OffCooldown() && GetComponentInParent<PlayerUnit>().UseStamina(staminaCost))
        {
            StartCooldown();
            GameObject o = (GameObject)Instantiate(fireball,
            new Vector3(playerUnit.RelativeOrigin.x, playerUnit.RelativeOrigin.y, 0), Quaternion.identity);
            o.GetComponent<Rigidbody2D>().velocity = playerUnit.RelativeMouse.normalized * 10;
        }
    }

    public override void ForceLoadIcon()
    {
        //Debug.Log("FORCE LOAD CALLED");
        if (!IsIconLoaded())
        {
            loadIcon("skill_fireball");
        }
    }

    public override string Title
    {
        get
        {
            return "Fireball";
        }
    }

    public override string Description
    {
        get
        {
            return "Launches a fireball";
        }
    }
}
