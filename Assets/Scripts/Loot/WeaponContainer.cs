using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponContainer : Container
{
    public GameObject WeaponPrefab;
    public GameObject PistolContainerPrefab;
    public GameObject ShotgunContainerPrefab;

    public override void Take()
    {
        var player = GameObject.Find("player");

        foreach(Transform child in player.transform)
        {
            var baseWeapon = child.GetComponent<BaseWeapon>();

            if (baseWeapon != null)
            {            
                if(baseWeapon.GetType() == typeof(PistolWeapon))
                {
                    Instantiate(PistolContainerPrefab, transform.position, Quaternion.identity);
                }
                else if (baseWeapon.GetType() == typeof(ShotgunWeapon))
                {
                    Instantiate(ShotgunContainerPrefab, transform.position, Quaternion.identity);
                }

                baseWeapon.Destroy();
                break;
            }
        }

        var newWeapon = Instantiate(WeaponPrefab, player.transform.position, Quaternion.identity);
        newWeapon.transform.parent = player.transform;
    }

}
