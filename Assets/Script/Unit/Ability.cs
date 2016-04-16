using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Unit))]
public abstract class Ability : MonoBehaviour, ILevelable {

	public int level;

	public float baseCooldown;

    public float cooldown;

    protected float cooldownReduction;

    public abstract void OnCast();

    public void SetCooldownReducation(float cdr)
    {
        this.cooldownReduction = cdr;
    }

    public void SetCooldown(float cooldown)
    {
        this.cooldown = cooldown;
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
}
