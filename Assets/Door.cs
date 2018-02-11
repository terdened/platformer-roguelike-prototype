using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    public bool IsRight;
    public bool IsLeft;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        var roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();

        if (IsRight)
            roomManager.MoveRight();

        if (IsLeft)
            roomManager.MoveLeft();
    }
}
