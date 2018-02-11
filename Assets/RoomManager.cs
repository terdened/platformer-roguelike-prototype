using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {
    public GameObject[][] roomInstances;
    public Vector2 currentPosition;
    public GameObject camera;
    public GameObject player;
    public int roomWidth = 18;
    public int roomHeight = 10;

    // Use this for initialization
    void Start () {
        SetCurrentPosition(new Vector2(0, 0));
    }

    public void MoveRight()
    {
        var newPosition = this.currentPosition;
        newPosition.x++;

        SetCurrentPosition(newPosition);
    }

    public void MoveLeft()
    {
        var newPosition = this.currentPosition;
        newPosition.x--;

        SetCurrentPosition(newPosition);
    }

    public void SetCurrentPosition(Vector2 newPosition)
    {
        currentPosition = newPosition;

        var roomCamera = camera.GetComponent<RoomCamera>();
        roomCamera.SetCurrnetRoom(new Vector2(currentPosition.x, currentPosition.y));

        player.transform.position = new Vector3(roomWidth * currentPosition.x, roomHeight * currentPosition.y - 2, player.transform.position.z);
    }
}
