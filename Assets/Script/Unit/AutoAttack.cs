using UnityEngine;
using System.Collections;

public class AutoAttack : MonoBehaviour {

    public float aaSpeed;
    public int autoDamage;

    private float nextaa;

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButtonDown("left_mouse_button"))
        {
            nextaa = Time.time + aaSpeed;
            if (other.GetComponentInParent<EnemyUnit>() != null)
            {
                other.GetComponentInParent<EnemyUnit>().Damage(autoDamage);
            } else if (other.GetComponentInChildren<Ability>() != null)
            {
                //Head a;
                if (other.GetComponentInChildren<LeftArm>() != null)
                {
                    LeftArm a = GetComponentInChildren<LeftArm>();
                    Destroy(a.gameObject);
                    other.transform.parent = gameObject.transform;

                    other.transform.parent = gameObject.transform;
                    other.transform.localPosition = new Vector3(0, 0, 0);
                    other.transform.localRotation = Quaternion.identity;
                } else if (other.GetComponentInChildren<RightArm>() != null )
                {
                    RightArm a = GetComponentInChildren<RightArm>();
                    Destroy(a.gameObject);
                    other.transform.parent = gameObject.transform;

                    other.transform.parent = gameObject.transform;
                    other.transform.localPosition = new Vector3(0, 0, 0);
                    other.transform.localRotation = Quaternion.identity;
                } else if ((other.GetComponentInChildren<Head>()) != null )
                {
                    Head a = GetComponentInChildren<Head>();
                    Destroy(a.gameObject);
                    other.transform.parent = gameObject.transform;
                    other.transform.localPosition = new Vector3(0, 0, 0);
                    other.transform.localRotation = Quaternion.identity;
                }
            }
        }

    }
}
