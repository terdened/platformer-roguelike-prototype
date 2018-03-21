using UnityEngine;

public class RoomCamera : MonoBehaviour {
    public Vector2 CurrentRoom;

    private float cameraSpeed = 0.5f;
    private int roomWidth = 18;
    private int roomHeight = 10;


    public RoomCamera()
    {
        CurrentRoom = new Vector2(0, 0);
    }
    // Use this for initialization
    void Start () {
		
	}

    public void SetCurrnetRoom(Vector2 newCurrentRoom)
    {
        CurrentRoom = newCurrentRoom;
    }
	
	// Update is called once per frame
	void Update ()
    {
        var targetPosition = new Vector3(roomWidth * CurrentRoom.x, roomHeight * CurrentRoom.y - roomHeight / 2, -10);

        if (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, cameraSpeed);
        }
    }
}
