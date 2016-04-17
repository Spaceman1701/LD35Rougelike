using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Unit))]
public abstract class Passive : MonoBehaviour, ILevelable {
    private const string DEFUALT_PASSIVE_FOLDER = "Sprite/passive/";

	public int level;

    private Sprite icon;

    public void LoadIcon(string name)
    {
        icon = Resources.Load<Sprite>(DEFUALT_PASSIVE_FOLDER + name);
    }

    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    public abstract string Title
    {
        get;
    }

    public abstract string Description
    {
        get;
    }

    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }

    public bool IsIconLoaded()
    {
        return icon == null;
    }

}
