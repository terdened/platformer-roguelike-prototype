using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BasePhysicsBehaviour))]
public class PlayerController : MonoBehaviour {
    private BasePhysicsBehaviour basePhysicsBehaviour;

    // Use this for initialization
    void Start () {
        basePhysicsBehaviour = GetComponent<BasePhysicsBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            basePhysicsBehaviour.AddForce(Vector3.up * 0.5f);
        }
    }
}
