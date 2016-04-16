using UnityEngine;
using System.Collections;
using UnityEngine.UI; //for abilities

public class Unit : MonoBehaviour {

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
	}
	
	// Update is called once per frame
	void Update()
    {
	    
	}
}
