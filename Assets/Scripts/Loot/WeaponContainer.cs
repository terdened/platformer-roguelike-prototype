using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponContainer : Container
{
    public GameObject weaponPrefab;
    public GameObject pistolContainerPrefab;
    public GameObject shotgunContainerPrefab;

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
                    Instantiate(pistolContainerPrefab, transform.position, Quaternion.identity);
                }
                else if (baseWeapon.GetType() == typeof(ShotgunWeapon))
                {
                    Instantiate(shotgunContainerPrefab, transform.position, Quaternion.identity);
                }

                baseWeapon.Destroy();
                break;
            }
        }

        var newWeapon = Instantiate(weaponPrefab, player.transform.position, Quaternion.identity);
        newWeapon.transform.parent = player.transform;
    }

}
