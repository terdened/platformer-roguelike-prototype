using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Container : MonoBehaviour
{
    private bool IsActive = false;

    void Update()
    {
        if (IsActive && Input.GetButtonDown(PC2D.Input.INTERACT))
        {
            Take();
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

    public abstract void Take();
}
