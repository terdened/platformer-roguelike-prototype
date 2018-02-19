using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolWeapon : BaseWeapon {
    // Use this for initialization

    protected override void Fire()
    {
        var direction = new Vector3();
        direction.x = Mathf.Abs(Input.GetAxis("HorizontalRight")) > 0.4f ? Input.GetAxis("HorizontalRight") > 0 ? 1 : -1 : 0;
        direction.y = Mathf.Abs(Input.GetAxis("VerticalRight")) > 0.4f ? Input.GetAxis("VerticalRight") > 0 ? 1 : -1 : 0;

        InitBulet(direction);
    }
}
