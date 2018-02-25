using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponContainer : MonoBehaviour {
    public GameObject weaponPrefab;
    private bool IsActive = false;
    public GameObject pistolContainerPrefab;
    public GameObject shotgunContainerPrefab;

    void Update()
    {
        if (IsActive && Input.GetButtonDown(PC2D.Input.INTERACT))
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

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IsActive = true;
        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.green;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        IsActive = false;
        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.white;
    }
}
