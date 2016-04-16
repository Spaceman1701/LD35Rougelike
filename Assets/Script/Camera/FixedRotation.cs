using UnityEngine;
using System.Collections;

public class FixedRotation : MonoBehaviour {

    private Quaternion rotation; 

	void Awake()
    {
        rotation = transform.rotation;
    }

    void Update()
    {
        transform.rotation = rotation;
    }

    void EarlyUpdate()
    {
        transform.rotation = rotation;
    }

    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}
