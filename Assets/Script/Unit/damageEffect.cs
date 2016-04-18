using UnityEngine;
using System.Collections;

public class damageEffect : MonoBehaviour, DamageListener{

    public SpriteRenderer[] spriteRenders;
    public float damageColorTime;

    // Use this for initialization
    public void OnDamageTaken(float dmg)
    {
        
       
        spriteRenders = GetComponentsInChildren<SpriteRenderer>();

        foreach(SpriteRenderer r in spriteRenders)
        {
           r.color = Color.red;
        }
        Invoke("ResetColor", damageColorTime);

    }

    private void ResetColor()
    {
        foreach (SpriteRenderer r in spriteRenders)
        {
            r.color = Color.white;
        }
    }


}
