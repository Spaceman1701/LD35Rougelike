using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	[SerializeField]
	private RectTransform healthBarRect;
	[SerializeField]
	private Text healthText;

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
	public void SetHealth(int cur, int max)
	{
		float value = (float)cur / max;

		healthBarRect.localScale = new Vector3 (value, healthBarRect.localScale.y, healthBarRect.localScale.z);
		healthText.text = cur + " / " + max;
	}
}