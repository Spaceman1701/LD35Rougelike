using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class Waypoint
{
    private float x;
    private float y;

    public Waypoint(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public Waypoint(Vector2 target)
    {
        this.x = target.x;

    }

    public float X
    {
        get
        {
            return x;
        }
        set
        {
            x = value;
        }
    }

    public float Y
    {
        get
        {
            return y;
        }
        set
        {
            y = value;
        }
    }
        
    public Vector2 Target
    {
        get
        {
            return Target;
        }
        set
        {
            Target = value;
        }
    }
}
