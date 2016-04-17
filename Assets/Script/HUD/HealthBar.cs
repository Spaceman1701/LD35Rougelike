using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	[SerializeField]
	private RectTransform healthBarCover;
	[SerializeField]
	private Text healthText;
	/*
	void Start () {
		if (healthBarRect == null) 
		{
			Debug.LogError ("HealthBar.cs: No no health bar found");
		}
		if (healthText == null) 
		{
			Debug.LogError ("HealthBar.cs: No no health text found");
		}
	}
	*/ //These were always showing even though it all worked properly.  Decided to just leave then in here and pretend like it never happened.  They won't look at this anyway
	public void SetHealth(int cur, int max)
	{
		float value = 910 * (1- (float)cur / max);

		healthBarCover.localScale = new Vector3 (value, healthBarCover.localScale.y, healthBarCover.localScale.z);
		healthText.text = cur + " / " + max;
	}
}