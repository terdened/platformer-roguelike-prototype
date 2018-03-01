using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletScript : MonoBehaviour {
    private float speed;
    private float distance;
    private float damage;

    private Vector3 startPosition;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
    }

    public void Init(Vector3 direction, float speed, float distance, float damage)
    {
        this.direction = direction;
        this.speed = speed;
        this.distance = distance;
        this.damage = damage;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * speed * Time.deltaTime);
		if(Vector3.Distance(startPosition, transform.position) > distance) {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other);
        Destroy(gameObject);
    }
}
