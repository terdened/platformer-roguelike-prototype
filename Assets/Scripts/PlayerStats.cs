using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    public Text dmgText;
    public Text frText;
    public Text bsText;
    public Text bdText;

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

    void Update()
    {
        var player = GameObject.Find("player");

        BaseWeapon weapon = null;

        foreach (Transform child in player.transform)
        {
            var baseWeapon = child.GetComponent<BaseWeapon>();
            if(baseWeapon != null)
            {
                weapon = baseWeapon;
                break;
            }
        }

        if(weapon != null)
        {
            dmgText.text = (InitialDamage * weapon.DamageK).ToString();
            frText.text = (InitialFireRate * weapon.FireRateK).ToString();
            bsText.text = (InitialBuletSpeed * weapon.BuletSpeedK).ToString();
            bdText.text = (InitialBuletDistance * weapon.BuletDistanceK).ToString();
        }
    }
}
