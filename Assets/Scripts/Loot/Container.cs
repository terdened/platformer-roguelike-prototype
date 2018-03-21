using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Container : MonoBehaviour
{
    private bool isActive = false;

    void Update()
    {
        if (isActive && Input.GetButtonDown(PC2D.Input.INTERACT))
        {
            Take();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isActive = true;
        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.green;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isActive = false;
        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.white;
    }

    public abstract void Take();
}
