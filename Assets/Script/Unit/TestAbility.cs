using UnityEngine;
using System.Collections;

public class TestAbility : Ability {

    public GameObject projectile;
    
    public override void OnCast()
    {
        if (OffCooldown())
        {
            StartCooldown();

            GameObject o = Instantiate(projectile);
            o.GetComponent<Rigidbody2D>().velocity = playerUnit.RelativeMouse.normalized * 10;
        }
    }
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
