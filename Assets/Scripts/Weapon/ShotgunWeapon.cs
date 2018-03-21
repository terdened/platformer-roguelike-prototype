using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : BaseWeapon {
    public int BuletCount;

    protected override void Fire()
    {
        float originalDamage = DamageK;
        for (int i = 0; i < BuletCount; i++)
        {
            var direction = new Vector3();
            direction.x = Mathf.Abs(Input.GetAxis("HorizontalRight")) > 0.4f ? Input.GetAxis("HorizontalRight") > 0 ? 1 : -1 : 0;
            direction.y = Mathf.Abs(Input.GetAxis("VerticalRight")) > 0.4f ? Input.GetAxis("VerticalRight") > 0 ? 1 : -1 : 0;

            direction = Quaternion.Euler(0, 0, Random.Range(-15, 15)) * direction;

            DamageK *= Random.Range(0.6f, 1.4f);
            InitBulet(direction);
            DamageK = originalDamage;
        }
    }
}
