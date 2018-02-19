using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    // Fire
    private float InitialFireRate = 0.4f; // 1 = 1 bulet/sec, 0.5 = 2 bulet/sec
    private float InitialDamage = 1f;
    private float InitialBuletDistance = 8f;
    private float InitialBuletSpeed = 10f;

    // Movement
    private float InitialJumpPower;
    private float InitialMoveSpeed;

    public float GetFireRate()
    {
        return InitialFireRate;
    }

    public float GetDamage()
    {
        return InitialDamage;
    }

    public float GetBuletDistance()
    {
        return InitialBuletDistance;
    }

    public float GetBuletSpeed()
    {
        return InitialBuletSpeed;
    }

    public float GetJumpPower()
    {
        return InitialJumpPower;
    }

    public float GetMoveSpeed()
    {
        return InitialMoveSpeed;
    }
}
