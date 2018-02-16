using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletScript : MonoBehaviour {
    public float speed;
    public float distance;
    public float damage;

    private Vector3 startPosition;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
    }

    public void Init(Vector3 direction)
    {
        this.direction = direction;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * speed * Time.deltaTime);
		if(Vector3.Distance(startPosition, transform.position) > distance) {
            Destroy(gameObject);
        }
	}
}
