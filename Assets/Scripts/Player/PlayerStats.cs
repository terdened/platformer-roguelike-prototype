using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    public Text DmgText;
    public Text FrText;
    public Text BsText;
    public Text BdText;
    
    public List<StatEffect> Effects;

    // Fire
    private float initialFireRate = 0.4f; // 1 = 1 bulet/sec, 0.5 = 2 bulet/sec
    private float initialDamage = 1f;
    private float initialBuletDistance = 8f;
    private float initialBuletSpeed = 10f;

    // Movement
    private float initialJumpPower;
    private float initialMoveSpeed;

    public float GetFireRate()
    {
        var result = initialFireRate + Effects.Sum(_ => _.AdditionalFireRate);
        return result > 0.1f ? result : 0.1f;
    }

    public float GetDamage()
    {
        return initialDamage + Effects.Sum(_ => _.AdditionalDamage);
    }

    public float GetBuletDistance()
    {
        return initialBuletDistance + Effects.Sum(_ => _.AdditionalBuletDistance);
    }

    public float GetBuletSpeed()
    {
        return initialBuletSpeed + Effects.Sum(_ => _.AdditionalBuletSpeed);
    }

    public float GetJumpPower()
    {
        return initialJumpPower + Effects.Sum(_ => _.AdditionalJumpPower);
    }

    public float GetMoveSpeed()
    {
        return initialMoveSpeed + Effects.Sum(_ => _.AdditionalMoveSpeed);
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
            DmgText.text = (GetDamage() * weapon.DamageK).ToString();
            FrText.text = (GetFireRate() * weapon.FireRateK).ToString();
            BsText.text = (GetBuletSpeed() * weapon.BuletSpeedK).ToString();
            BdText.text = (GetBuletDistance() * weapon.BuletDistanceK).ToString();
        }
    }
}
