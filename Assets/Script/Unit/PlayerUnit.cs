using UnityEngine;
using System.Collections;

public class PlayerUnit : Unit {

    public Vector2 relativeMouse;

    public Ability abilityOne;

    protected override void OnStart()
    {
        UpdateRelativeMouse();
    }

    protected override void OnUpdate()
    {
        UpdateRelativeMouse();


        HandleAbilityInput();
    }


    private void HandleAbilityInput()
    {
        if (Input.GetButtonDown("Ability1"))
        {
            abilityOne.OnCast();
        }
    }

    private void UpdateRelativeMouse()
    {
        Vector2 mouseLoc = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        relativeMouse = mouseLoc - new Vector2(transform.position.x, transform.position.y);
    }

    public Vector2 RelativeMouse
    {
        get
        {
            return new Vector2(relativeMouse.x, relativeMouse.y);
        }
    }   
}
