using UnityEngine;
using System.Collections;

public class Head : MonoBehaviour {
    public int i;

    // Use this for initialization
    void Start () {
        Debug.Log("head");
	}
	
	// Update is called once per frame
	void Update () {
        i = 0;

        if (GetComponentInParent<Unit>() != null)
        {
            //transform.position = new Vector3(0, 0, 0);
            //transform.rotation = Quaternion.identity;
        }
	}
}
