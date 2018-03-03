using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public bool IsRight;
    public bool IsLeft;
    public bool IsUp;
    public bool IsDown;

    public bool IsOpen = true;
    private bool IsActive = false;

    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {
        if (IsActive && IsOpen && Input.GetButtonDown(PC2D.Input.INTERACT))
        {
            var roomManager = GameObject.Find("stage_manager").GetComponent<StageManager>();

            if (IsRight)
                roomManager.MoveRight();

            if (IsLeft)
                roomManager.MoveLeft();

            if (IsUp)
                roomManager.MoveUp();

            if (IsDown)
                roomManager.MoveDown();

            IsActive = false;
            var spriteRenderer = GetComponent<SpriteRenderer>();

            spriteRenderer.color = Color.white;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        IsActive = true;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        
        spriteRenderer.color = IsOpen ? Color.green : Color.red;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        IsActive = false;
        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = Color.white;
    }
}
