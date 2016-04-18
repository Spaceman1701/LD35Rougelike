using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	public GameObject playerGameObject;
	public Texture EmptyAbility;

    public Button ability1button;
    public Button ability2button;
    public Button ability3button;
    public Button ability4button;

    // Use this for initialization
    void Start () {
		Ability[] abilities  = playerGameObject.GetComponentsInChildren<Ability>();
//		float[] abilityIconXLocations = new float[4] {(float)-206.33, (float)-37.8, (float)127.5, (float)296.0};
//		float abilityIconYLocation = (float)-424.74;
		Button[] buttons = new Button[4] {ability1button, ability2button, ability3button, ability4button};

		int length = abilities.Length;
		for (int i = 0; i < length; i++) 
		{
			if (abilities[i] != null)
			{
                Debug.Log(abilities[i].Icon == null);
                abilities[i].ForceLoadIcon();
				buttons[i].image.overrideSprite = abilities[i].Icon;

                //GUI.Button (new Rect(-206.33f, -37.8f, 150, 150), abilities[i].Icon.texture); //THERE IS NO CURRENT TEXTURE ACCESSED THIS WAY
			}
			else 
			{
				//GUI.Button (new Rect(abilityIconXLocations[i], abilityIconYLocation, 150, 150), EmptyAbility); 
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		HealthBar healthBar = GetComponent <HealthBar>();
		StaminaBar staminaBar = GetComponent <StaminaBar>();
		healthBar.SetHealth ((int)playerGameObject.GetComponent<PlayerUnit>().health, (int)playerGameObject.GetComponent<PlayerUnit>().maxHealth);
		staminaBar.SetStamina ((int)playerGameObject.GetComponent<PlayerUnit>().stamina, (int)playerGameObject.GetComponent<PlayerUnit>().maxStamina);

		Ability[] abilities  = playerGameObject.GetComponentsInChildren<Ability>();
//		float[] abilityIconXLocations = new float[4] {(float)-206.33, (float)-37.8, (float)127.5, (float)296.0};
//		float abilityIconYLocation = (float)-424.74;
		Button[] buttons = new Button[4] {ability1button, ability2button, ability3button, ability4button};

		int length = abilities.Length;
		for (int j = 0; j < length; j++) 
		{
			if (abilities[j] != null)
			{
				Debug.Log(abilities[j].Icon == null);
				abilities[j].ForceLoadIcon();
				buttons[j].image.overrideSprite = abilities[j].Icon;

				//GUI.Button (new Rect(-206.33f, -37.8f, 150, 150), abilities[i].Icon.texture); //THERE IS NO CURRENT TEXTURE ACCESSED THIS WAY
			}
			else 
			{
				//GUI.Button (new Rect(abilityIconXLocations[i], abilityIconYLocation, 150, 150), EmptyAbility); 
			}
		}

		//Ability cooldowns
		for (int i = 0; i < length; i++)
		{
			if (abilities [i].cooldown > 0) 
			{

			}
		}
	}
}

//Use the array of abilities to change the text box.  On mouseover on a button, call the show description function on this and pass which ability it is.  Then create a text box using the ability at that index in the array
