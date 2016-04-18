using UnityEngine;
using System.Collections;

public class AutoAttack : MonoBehaviour {

    public Collider2D c;

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButtonDown("left_mouse_button"))
        {
            Debug.Log("ado.lkjadskljsd");
        }
    }
}
