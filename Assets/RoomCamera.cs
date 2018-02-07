using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamera : MonoBehaviour {
    public int roomWidth = 18;
    public int roomHeight = 10;

    public Vector2 currentRoom;

    public RoomCamera()
    {
        currentRoom = new Vector2(0, 0);
    }
    // Use this for initialization
    void Start () {
		
	}

    public void SetCurrnetRoom(Vector2 newCurrentRoom)
    {
        currentRoom = newCurrentRoom;
        var newPosition = new Vector3(roomWidth * currentRoom.x, roomHeight * currentRoom.y - roomHeight / 2, -10);
        transform.position = newPosition;
    }
	
	// Update is called once per frame
	void Update () {
    }
}
