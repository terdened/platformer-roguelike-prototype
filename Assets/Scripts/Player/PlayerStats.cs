using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public List<StatEffect> effects;

    public float GetFireRate()
    {
        var result = InitialFireRate + effects.Sum(_ => _.AdditionalFireRate);
        return result > 0.1f ? result : 0.1f;
    }

    public float GetDamage()
    {
        return InitialDamage + effects.Sum(_ => _.AdditionalDamage);
    }

    public float GetBuletDistance()
    {
        return InitialBuletDistance + effects.Sum(_ => _.AdditionalBuletDistance);
    }

    public float GetBuletSpeed()
    {
        return InitialBuletSpeed + effects.Sum(_ => _.AdditionalBuletSpeed);
    }

    public float GetJumpPower()
    {
        return InitialJumpPower + effects.Sum(_ => _.AdditionalJumpPower);
    }

    public float GetMoveSpeed()
    {
        return InitialMoveSpeed + effects.Sum(_ => _.AdditionalMoveSpeed);
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
            dmgText.text = (GetDamage() * weapon.DamageK).ToString();
            frText.text = (GetFireRate() * weapon.FireRateK).ToString();
            bsText.text = (GetBuletSpeed() * weapon.BuletSpeedK).ToString();
            bdText.text = (GetBuletDistance() * weapon.BuletDistanceK).ToString();
        }
    }
}
