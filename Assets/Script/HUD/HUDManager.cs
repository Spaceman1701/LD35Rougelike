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
		healthBar.SetHealth (5, 10);
		staminaBar.SetStamina (657, 1000);
	}
}
