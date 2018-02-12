using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamera : MonoBehaviour {
    public int roomWidth = 18;
    public int roomHeight = 10;
    private float cameraSpeed = 0.5f;

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
        //var newPosition = new Vector3(roomWidth * currentRoom.x, roomHeight * currentRoom.y - roomHeight / 2, -10);
       // transform.position = newPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {
        var targetPosition = new Vector3(roomWidth * currentRoom.x, roomHeight * currentRoom.y - roomHeight / 2, -10);

        if (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, cameraSpeed);
            //Debug.Log(deltaPosition);
            // = transform.position + deltaPosition;
        }
    }
}
