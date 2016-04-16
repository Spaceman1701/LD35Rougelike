using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Unit))]
public abstract class Passive : MonoBehaviour, ILevelable {

	public int level;

}
