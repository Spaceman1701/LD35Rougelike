using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		HealthBar healthBar = GetComponent <HealthBar>();
		StaminaBar staminaBar = GetComponent <StaminaBar>();
		healthBar.SetHealth (247, 550);
		staminaBar.SetStamina (500, 1000);
	}
}
