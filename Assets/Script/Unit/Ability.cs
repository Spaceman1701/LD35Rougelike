using UnityEngine;
using System.Collections;
using System;

[RequireComponent (typeof(PlayerUnit))]
public abstract class Ability : MonoBehaviour, ILevelable {
    private const float COOLDOWN_UPATE_RATE = 0.1f;

	public int level;

	public float baseCooldown;

    public float cooldown;

    protected float cooldownReduction;

    public PlayerUnit playerUnit;

    public abstract void OnCast();

    public void SetCooldownReducation(float cdr)
    {
        this.cooldownReduction = cdr;
    }

    public void SetCooldown(float cooldown)
    {
        this.cooldown = cooldown;
    }

    public void StartCooldown()
    {
        cooldown = baseCooldown;
        InvokeRepeating("IncrementCooldown", 0, COOLDOWN_UPATE_RATE);
    }

    private void IncrementCooldown()
    {
        cooldown -= COOLDOWN_UPATE_RATE;
        if (cooldown <= 0.0)
        {
            CancelInvoke("IncrementCooldown");
            cooldown = 0;
        }
    }

    public bool OffCooldown()
    {
        return cooldown == 0;
    }

    public float BaseCooldown
    {
        get
        {
            return baseCooldown;
        }
    }

    public float Cooldown
    {
        get
        {
            return cooldown;
        }
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
}
