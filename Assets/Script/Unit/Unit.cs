using UnityEngine;
using System.Collections;
using UnityEngine.UI; //for abilities

public abstract class Unit : MonoBehaviour, ILevelable {

	public int level;

	public float maxHealth;
    public float maxStamina;

    public float health;
    public float stamina;

    public float healthRegenRate;
    public float staminaRegenRate;

    public float baseHealthRegen;
    public float baseStaminaRegen;

    public float cdrPercent;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;

        healthRegenRate = baseHealthRegen;
        staminaRegenRate = baseStaminaRegen;

        OnStart();
	}

    protected abstract void OnStart();
    protected abstract void OnUpdate();
    protected abstract void OnMoveStart();
    protected abstract void OnMoveEnd();
    protected abstract void OnDeath();
	// Update is called once per frame
	void Update()
    {
        HandleAnimation();
        if (health <= 0)
        {
            ZeroHealthListener[] listeners = GetComponentsInChildren<ZeroHealthListener>();
            foreach (ZeroHealthListener h in listeners)
            {
                h.OnZeroHealth();
            }
            if (health <= 0)
            {
                OnDeath();
            }
        }
        OnUpdate();
	}

    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    public void StartMoving()
    {
        OnMoveStart();


        Animate[] moveAnimation = GetComponentsInChildren<Animate>();
        foreach (Animate a in moveAnimation)
        {
            //a.StartAnimate();
        }
    }

    public void EndMoving()
    {
        OnMoveEnd();

        Animate[] moveAnimation = GetComponentsInChildren<Animate>();
        foreach (Animate a in moveAnimation)
        {
            //a.StopAnimate();
        }
    }

    private void HandleAnimation()
    {
        Animate[] animates = GetComponentsInChildren<Animate>();
        foreach (Animate a in animates)
        {
            if (GetComponent<Rigidbody2D>().velocity.magnitude > 0)
            {
                a.StartAnimate();
            }
            else
            {
                a.StopAnimate();
            }
        }
    }

    public Vector2 RelativeOrigin
    {
        get
        {
            return transform.position;
        }
    }

    public void Damage(float damage)
    {
        DamageListener[] listeners = GetComponentsInChildren<DamageListener>();
        foreach (DamageListener l in listeners)
        {
            l.OnDamageTaken(damage);
        }
        health -= damage;
    }

    public void Heal(float amount)
    {
        HealListener[] listeners = GetComponentsInChildren<HealListener>();
        foreach (HealListener l in listeners)
        {
            l.OnHeal(amount);
        }

        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public float CDR
    {
        get
        {
            return cdrPercent;
        }
        set
        {
            cdrPercent = value;
        }
    }
}
