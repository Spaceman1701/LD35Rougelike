using UnityEngine;
using System.Collections;

public class TestAbility : Ability {

    public GameObject projectile;
    
    public override void OnCast()
    {
        if (OffCooldown())
        {
            StartCooldown();

            GameObject o = (GameObject)Instantiate(projectile, 
                new Vector3(playerUnit.RelativeOrigin.x, playerUnit.RelativeOrigin.y, 0), Quaternion.identity);
            o.GetComponent<Rigidbody2D>().velocity = playerUnit.RelativeMouse.normalized * 10;
        }
    }
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override string Title
    {
        get
        {
            return "TestAbility!";
        }
    }

    public override string Description
    {
        get
        {
            return "MASSIVE DAMAGE. MUCH WOW. VERY SKILLSHOT";
        }
    }
}
