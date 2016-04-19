using UnityEngine;
using System.Collections;

public class FireballProjectile : MonoBehaviour {

    public int damage;
    public float startingLifetime;

    float lifetime;
    private const float LIFETIME_UPATE_RATE = 0.1f;

    void Start()
    {
        lifetime = startingLifetime;
        InvokeRepeating("DecreaseLifetime", 0, LIFETIME_UPATE_RATE);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponentInParent<EnemyUnit>())
        {
            other.GetComponentInParent<EnemyUnit>().Damage(damage);
            CancelInvoke("DecreaseLifetime");
            Destroy(gameObject);
        }
    }
    private void DecreaseLifetime()
    {
        lifetime -= LIFETIME_UPATE_RATE;
        if (lifetime <= 0.0)
        {
            CancelInvoke("DecreaseLifetime");
            Destroy(gameObject);
        }
    }


}
