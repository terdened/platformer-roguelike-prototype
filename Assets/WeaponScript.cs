using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
    public GameObject buletPrefab;
    public float fireRate = 0.4f;
    private float fireTimer = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (fireTimer > 0)
            fireTimer -= Time.deltaTime;

        if ((Mathf.Abs(Input.GetAxis("HorizontalRight")) > 0.4f || Mathf.Abs(Input.GetAxis("VerticalRight")) > 0.4f) && fireTimer <= 0)
        {
            Debug.Log("fire!");
            fireTimer = fireRate;
            var buletInstance = Instantiate(buletPrefab, transform.parent.transform.position, Quaternion.identity);
            var buletScript = buletInstance.GetComponent<BuletScript>();

            var direction = new Vector3();
            direction.x = Mathf.Abs(Input.GetAxis("HorizontalRight")) > 0.4f ? Input.GetAxis("HorizontalRight") > 0 ? 1 : -1 : 0;
            direction.y = Mathf.Abs(Input.GetAxis("VerticalRight")) > 0.4f ? Input.GetAxis("VerticalRight") > 0 ? 1 : -1 : 0;
            buletScript.Init(direction);
        }
    }
}
