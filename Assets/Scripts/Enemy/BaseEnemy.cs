using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {
    public float HealthPower = 10f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MakeDamage(float damage)
    {
        HealthPower -= damage;

        if (HealthPower <= 0)
            Destroy(gameObject);
    }
}
