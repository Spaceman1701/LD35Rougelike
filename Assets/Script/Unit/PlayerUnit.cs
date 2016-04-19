using UnityEngine;
using System.Collections;
using System;

public class PlayerUnit : Unit {

    public Vector2 relativeMouse;

    public Ability abilityOne;
    public Ability abilityTwo;
    public Ability abilityThree;
    public Ability abilityFour;

    protected override void OnStart()
    {
        UpdateRelativeMouse();
        //StartMoving();
    }

    protected override void OnDeath()
    {
        
    }

    protected override void OnUpdate()
    {
        UpdateRelativeMouse();


        HandleAbilityInput();
    }

    public bool UseStamina(float amount)
    {
        if (stamina >= amount)
        {
            stamina -= amount;
            return true;
        }
        return false;
    }

    public bool UseHealth(float amount, float minHealthRemaining)
    {
        if (health-minHealthRemaining >= amount)
        {
            health -= amount;
            return true;
        }
        return false;
    }

    public Ability Ability1
    {
        get
        {
            if (GetComponentInChildren<Ability1>() == null)
            {
                return null;
            }
            return GetComponentInChildren<Ability1>().ability;
        }
    }

    public Ability Ability2
    {
        get
        {
            if (GetComponentInChildren<Ability2>() == null)
            {
                return null;
            }
            return GetComponentInChildren<Ability2>().ability;
        }
    }

    public Ability Ability3
    {
        get
        {
            if (GetComponentInChildren<Ability3>() == null)
            {
                return null;
            }
            return GetComponentInChildren<Ability3>().ability;
        }
    }

    public Ability Ability4
    {
        get
        {
            if (GetComponentInChildren<Ability4>() == null)
            {
                return null;
            }
            return GetComponentInChildren<Ability4>().ability;
        }
    }

    private void HandleAbilityInput()
    {
        if (Input.GetButtonDown("Ability1"))
        {
            if (Ability1 != null)
            {
                Ability1.OnCast();
            }
        }
        if (Input.GetButtonDown("Ability2"))
        {
            if (Ability2 != null)
            {
                Ability2.OnCast();
            }
        }
        if (Input.GetButtonDown("Ability3"))
        {
            if (Ability3 != null)
            {
                Ability3.OnCast();
            }
        }
        if (Input.GetButtonDown("Ability4"))
        {
            if (Ability4 != null) {
                Ability4.OnCast();
            }
        }
    }

    private void UpdateRelativeMouse()
    {
        Vector2 mouseLoc = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        relativeMouse = mouseLoc - new Vector2(transform.position.x, transform.position.y);
    }

    public Unit GetUnitUnderMouse()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0.0f);
        if (hit.rigidbody != null)
        {
            Unit u = hit.rigidbody.transform.GetComponentInChildren<Unit>();
            if (u != null)
            {
                return u;
            }
        }
        return null;
    }

    public Vector2 RelativeMouse
    {
        get
        {
            return new Vector2(relativeMouse.x, relativeMouse.y);
        }
    }
    
    protected override void OnMoveStart()
    {

    }   

    protected override void OnMoveEnd()
    {

    }
}
