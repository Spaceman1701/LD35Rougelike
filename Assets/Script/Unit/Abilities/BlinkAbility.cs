using UnityEngine;
using System.Collections;
using System;

public class BlinkAbility : Ability {

    public override void OnCast()
    {
        if (OffCooldown()&&GetComponentInParent<PlayerUnit>().UseStamina(staminaCost))
        {
            StartCooldown();
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            GetComponentInParent<PlayerUnit>().transform.position = pz;
        }
    }

    public override void ForceLoadIcon()
    {
        //Debug.Log("FORCE LOAD CALLED");
        if (!IsIconLoaded())
        {
            loadIcon("skill_blink");
        }
    }

    public override string Title
    {
        get
        {
            return "Blink";
        }
    }

    public override string Description
    {
        get
        {
            return "Instantly move to the cursor. Very original ability.";
        }
    }
}
