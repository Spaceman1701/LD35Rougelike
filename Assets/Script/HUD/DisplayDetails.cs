using UnityEngine;
using System.Collections;

public class DisplayDetails : MonoBehaviour {

	Ability[] abilities = new Ability[4];
	int length;

	int abilityIndex = -1;
	public GameObject playerGameObject;

	public int x=0;
	public int y=0;

	void Start()
	{
        PlayerUnit pu = playerGameObject.GetComponent<PlayerUnit>();
		abilities = new Ability[] {pu.Ability1, pu.Ability2, pu.Ability3, pu.Ability4};
		length = abilities.Length;
	}

	public void showDetails(int index){
		abilityIndex = index;
	}

    private void DrawAbilityText(int abilityIndex)
    {
        if (abilities[abilityIndex] != null)
        {
            string abilityDesc = abilities[abilityIndex].Description;
            string abilityTitle = abilities[abilityIndex].Title;

            GUI.Label(new Rect(903, 523, 240, 30), abilityTitle);
            GUI.Label(new Rect(903, 542, 240, 300), abilityDesc);
        }
    }

	void OnGUI () {
//		GUI.Label (new Rect (x, y, 240, 30), "1.7");
//		GUI.Label(new Rect(x, y, 240, 300), "asjfhadlfkhdaslfjkgdasljkgadsjlf");
		length = abilities.Length;
        //Ability descriptions
        if (abilityIndex != -1)
        {
            DrawAbilityText(abilityIndex);

        }
        for (int i = 0; i < length; i++) {
			if (abilities[i] != null && abilities [i].cooldown > 0){
				float cooldownTime = abilities [i].cooldown;
				cooldownTime = Mathf.Round (cooldownTime * 100f) / 100f;
				if (i == 0)
					GUI.Label (new Rect (488, 550, 240, 30), cooldownTime.ToString());
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
		GUI.Label (new Rect (455, 602, 240, 300), level.ToString());
	}
}
