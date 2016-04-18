using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayDetails : MonoBehaviour {
    public int abilityNum;

    public Ability ability;
	int length;

	int abilityIndex = -1;
	public PlayerUnit pu;

	public int x=0;
	public int y=0;

    public Text cdText;
    public Text infoText;

    public bool details;

	void Start()
	{
        UpdateAbility();
	}

	public void ShowDetails()
    {
        details = true;
        if (details && ability != null)
        {
            string abilityDesc = ability.Description;
            string abilityTitle = ability.Title;

            infoText.text =
                abilityTitle + '\n' +
                abilityDesc;
        }
    
    }
    

    public void StopShowDetails()
    {
        details = false;
        infoText.text = "";
    }

    private void UpdateAbility()
    {
        switch (abilityNum)
        {
            case 0:
                ability = pu.Ability1;
                break;
            case 1:
                ability = pu.Ability2;
                break;
            case 3:
                ability = pu.Ability3;
                break;
            case 4:
                ability = pu.Ability4;
                break;
        }
    }

	void OnGUI () {
        UpdateAbility();
//		GUI.Label (new Rect (x, y, 240, 30), "1.7");
//		GUI.Label(new Rect(x, y, 240, 300), "asjfhadlfkhdaslfjkgdasljkgadsjlf");
        //Ability descriptions
        
        

        if (ability != null && !ability.OffCooldown())
        {
            float cooldownTime = Mathf.Round(ability.cooldown * 100f) / 100f;
            cdText.text = cooldownTime.ToString();
        } else
        {
            cdText.text = "";
        }
        
        /*
        for (int i = 0; i < length; i++) {
			if (abilities[i] != null && abilities [i].cooldown > 0){
				float cooldownTime = abilities [i].cooldown;
				cooldownTime = Mathf.Round (cooldownTime * 100f) / 100f;
				if (i == 0)
                    
                    GUI.Label(new Rect(, 200, 30), cooldownTime.ToString());
                //GUI.Label (new Rect (488, 550, 240, 30), cooldownTime.ToString());
                else if (i == 1)
					GUI.Label (new Rect (583, 550, 240, 30), cooldownTime.ToString());
				else if (i == 2)
					GUI.Label (new Rect (672, 550, 240, 30), cooldownTime.ToString());
				else if (i == 3)
					GUI.Label (new Rect (765, 550, 240, 30), cooldownTime.ToString());
			}
		}
		GUI.contentColor = Color.black;
		int level = playerGameObject.GetComponentInChildren<ILevelable> ().Level;
		GUI.Label (new Rect (455, 602, 240, 300), level.ToString()); */
	}
}
