using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {
    public float healthPower = 10f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MakeDamage(float damage)
    {
        healthPower -= damage;

        if (healthPower <= 0)
            Destroy(gameObject);
    }
}
