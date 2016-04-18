using UnityEngine;
using System.Collections;

public class AutoAttack : MonoBehaviour {

    public float aaSpeed;
    public int autoDamage;

    private float nextaa;

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButtonDown("left_mouse_button"))
        {
            nextaa = Time.time + aaSpeed;
            if (other.GetComponentInParent<EnemyUnit>())
            {
                other.GetComponentInParent<EnemyUnit>().Damage(autoDamage);
            }
        }

    }
}
