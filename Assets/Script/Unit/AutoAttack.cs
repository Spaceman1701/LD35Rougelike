using UnityEngine;
using System.Collections;

public class AutoAttack : MonoBehaviour {

    public float aaSpeed;
    public int autoDamage;

    private float aaCooldown;
    private const float COOLDOWN_UPATE_RATE = 0.1f;
    private PlayerMovement movement;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButton("left_mouse_button"))
        {
        if(OffCooldown())
            {
                StartCooldown();
                if (other.GetComponentInParent<EnemyUnit>())
                {
                    other.GetComponentInParent<EnemyUnit>().Damage(autoDamage);
                }
            }
        }
    }
    public void StartCooldown()
    {
        aaCooldown = aaSpeed;
        InvokeRepeating("IncrementCooldown", 0, COOLDOWN_UPATE_RATE);
    }

    private void IncrementCooldown()
    {
       aaCooldown -= COOLDOWN_UPATE_RATE;
        if (aaCooldown <= 0.0)
        {
            CancelInvoke("IncrementCooldown");
            aaCooldown = 0;
        }
    }

    public bool OffCooldown()
    {
        return aaCooldown == 0;
    }
}
