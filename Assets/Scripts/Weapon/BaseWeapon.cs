using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour {
    public GameObject buletPrefab;
    public float FireRateK;
    public float DamageK;
    public float BuletDistanceK;
    public float BuletSpeedK;
    private float fireTimer = 0;
    private PlayerStats playerStats;

    protected void Start()
    {
        playerStats = GameObject.Find("player_stats").GetComponent<PlayerStats>();
    }

    protected abstract void Fire();

    protected void InitBulet(Vector3 direction)
    {
        var buletInstance = Instantiate(buletPrefab, transform.parent.transform.position, Quaternion.identity);
        var buletScript = buletInstance.GetComponent<BuletScript>();
        buletScript.Init(direction, playerStats.GetBuletSpeed() * BuletSpeedK, playerStats.GetBuletDistance() * BuletDistanceK, playerStats.GetDamage() * DamageK);
    }

    protected void Update()
    {
        if (fireTimer > 0)
            fireTimer -= Time.deltaTime;

        if ((Mathf.Abs(Input.GetAxis("HorizontalRight")) > 0.4f || Mathf.Abs(Input.GetAxis("VerticalRight")) > 0.4f) && fireTimer <= 0)
        {
            fireTimer = playerStats.GetFireRate() * FireRateK;
            Fire();
        }
    }
}
