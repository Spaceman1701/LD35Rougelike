using UnityEngine;
using System.Collections;
using System;

public class EkkoUlt : Ability {

	//public PlayerUnit playerUnit;

	UltData[] arrayOfData = new UltData[40];
	int queueHead = 0;
	int queueTail = 0;
	int queueSize = 0;

	class UltData
	{
		public float[] abilityCooldowns = new float[3];
		public int storedAbilities;
		public float healthStore;
		public float staminaStore;
		public Vector3 formerLocation;
	}
	
	public override void OnCast()
	{
		if (OffCooldown())
		{
			StartCooldown();
			
			playerUnit.health = arrayOfData [queueHead].healthStore;
			playerUnit.stamina = arrayOfData [queueHead].staminaStore;
			playerUnit.transform.position = arrayOfData [queueHead].formerLocation;

			playerUnit.health = arrayOfData [queueHead].healthStore;
			Ability[] abilities = new Ability[] { playerUnit.Ability1, playerUnit.Ability2, playerUnit.Ability3, playerUnit.Ability4 };
			for (int i = 0; i < arrayOfData[queueHead].storedAbilities; i++){
				abilities[i].cooldown = arrayOfData[queueHead].abilityCooldowns[i];
			}
		}
	}
	
	// Use this for initialization
	void Start () {
		//loadIcon("TestAbility");
        for (int i = 0; i < arrayOfData.Length; i ++)
        {
            arrayOfData[i] = new UltData();
        }
		InvokeRepeating ("UltDataUpdate", 0f, .1f);
	}

	void UltDataUpdate()
	{
		float currentHealth = playerUnit.GetComponent<PlayerUnit> ().health;
		float currentStamina = playerUnit.GetComponent<PlayerUnit> ().stamina;
		Vector3 currentTransform = playerUnit.GetComponent<PlayerUnit> ().transform.position;
		
		Ability[] abilities = new Ability[] { playerUnit.Ability1, playerUnit.Ability2, playerUnit.Ability3};

		int length = abilities.Length;
		for (int i = 0; i < length; i++) 
		{
			if (abilities [i] != null) {
				arrayOfData[queueTail].abilityCooldowns[i] = abilities[i].cooldown;
				arrayOfData[queueTail].storedAbilities = i;
			}

		}

		arrayOfData [queueTail].healthStore = currentHealth;
		arrayOfData [queueTail].staminaStore = currentStamina;
		arrayOfData [queueTail].formerLocation = currentTransform;

		if (queueTail == 39) 
		{
			queueTail = 0;
		}else
		{
			queueTail++;
		}

		if (queueHead == queueTail) {
			queueHead++;
		}

		if (queueHead == 39) {
			queueHead = 0;
		}

		if (queueSize != 40) {
			queueSize++;
		}

	}

	void DrawTrail(){

	}

	public override void ForceLoadIcon()
	{
		//Debug.Log("FORCE LOAD CALLED");
		if (!IsIconLoaded())
		{
			loadIcon("skill_ekko");
		} 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override string Title
	{
		get
		{
			return "Temporal Echo";
		}
	}
	
	public override string Description
	{
		get
		{
			return "Transports you 4 seconds back in time";
		}
	}
}
