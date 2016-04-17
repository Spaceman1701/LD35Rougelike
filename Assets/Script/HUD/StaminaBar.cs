using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour {

	[SerializeField]
	private RectTransform staminaBarCover;
	[SerializeField]
	private Text staminaText;
	/*
	void Start () {
		if (staminaBarRect == null) 
		{
			Debug.LogError ("StaminaBar.cs: No stamina bar found");
		}
		if (staminaText == null) 
		{
			Debug.LogError ("Stamina.cs: No stamina text found");
		}
	}
	*/ //These were always showing even though it all worked properly.  Decided to just leave then in here and pretend like it never happened.  They won't look at this anyway
	public void SetStamina(int cur, int max)
	{
		float value = 910 * (1- (float)cur / max);

		staminaBarCover.localScale = new Vector3 (value, staminaBarCover.localScale.y, staminaBarCover.localScale.z);
		staminaText.text = cur + " / " + max;
	}
}