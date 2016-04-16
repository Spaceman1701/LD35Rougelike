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
	// Update is called once per frame
	void Update()
    {
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
            a.StartAnimate();
        }
    }

    public void EndMoving()
    {
        OnMoveEnd();

        Animate[] moveAnimation = GetComponentsInChildren<Animate>();
        foreach (Animate a in moveAnimation)
        {
            a.StopAnimate();
        }
    }
}
