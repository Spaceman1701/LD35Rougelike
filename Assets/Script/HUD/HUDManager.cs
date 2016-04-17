using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour {

	public GameObject playerGameObject;
	public Texture EmptyAbility;

	// Use this for initialization
	void Start () {
		Ability[] abilities  = playerGameObject.GetComponentsInChildren<Ability>();
		float[] abilityIconXLocations = new float[4] {(float)-206.33, (float)-37.8, (float)127.5, (float)296.0};
		float abilityIconYLocation = (float)-424.74;

		int length = abilities.Length;
		for (int x = 0; x < 4; x++) 
		{
			if (abilities[x] != null)
			{
//				GUI.Button (new Rect(abilityIconXLocations[x], abilityIconYLocation, 150, 150), abilities[x].Icon); //THERE IS NO CURRENT TEXTURE ACCESSED THIS WAY
			}
			else 
			{
				GUI.Button (new Rect(abilityIconXLocations[x], abilityIconYLocation, 150, 150), EmptyAbility); 
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		HealthBar healthBar = GetComponent <HealthBar>();
		StaminaBar staminaBar = GetComponent <StaminaBar>();
		healthBar.SetHealth (247, 550);
		staminaBar.SetStamina (500, 1000);
	}
}
