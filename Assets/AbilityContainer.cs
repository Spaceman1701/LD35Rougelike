using UnityEngine;
using System.Collections;

public class AbilityContainer : MonoBehaviour {

	public Ability ability
    {
        get
        {
            return GetComponentInChildren<Ability>();
        }
    }
}
