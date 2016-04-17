using UnityEngine;
using System.Collections;

public abstract class AutoAttack : MonoBehaviour {

    public float autoTime;

    public float autoRange;

    public float damage;

    private Unit autoTarget;

    public void StartAuto(Unit target)
    {
        if (InAutoRange(target))
        {
            Invoke("DoAuto", autoTime);
            autoTarget = null;
        }
    }

    protected bool InAutoRange(Unit t)
    {
        return RangeToTarget(t) <= autoRange;
    }

    public void DoAuto()
    {
        if (autoTarget != null)
        {
            autoTarget.Damage(damage);
        }
    }

    public void CancelAuto()
    {
        CancelInvoke("DoAuto");
    }


    private float RangeToTarget(Unit target)
    {
        return (target.transform.position - transform.position).magnitude;
    }

}
