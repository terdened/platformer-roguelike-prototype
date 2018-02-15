using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {
    public Vector2 currentPosition;
    public GameObject camera;
    public GameObject player;
    public GameObject levelBuilderPrefab;
    public int roomWidth = 18;
    public int roomHeight = 10;
    private GameObject[][] roomInstances;
    private MinimapScript miniMap;

    // Use this for initialization
    void Start () {
        var levelBuilder = levelBuilderPrefab.GetComponent<LevelBuilder>();
        miniMap = GameObject.Find("mini_map").GetComponent<MinimapScript>();

        levelBuilder.Generate();
        roomInstances = levelBuilder.RoomInstances;

        miniMap.SetRooms(levelBuilder.Rooms);

        SetCurrentPosition(new Vector2(4, 4));
        player.transform.position = new Vector3(roomWidth * currentPosition.x, roomHeight * currentPosition.y - 2, player.transform.position.z);
    }

    public void MoveRight()
    {
        var newPosition = this.currentPosition;
        newPosition.x++;

        SetCurrentPosition(newPosition);
        player.transform.position = new Vector3(roomWidth * currentPosition.x - 7.5f, roomHeight * currentPosition.y - 8.5f, player.transform.position.z);
    }

    public void MoveLeft()
    {
        var newPosition = this.currentPosition;
        newPosition.x--;

        SetCurrentPosition(newPosition);
        player.transform.position = new Vector3(roomWidth * currentPosition.x + 7.5f, roomHeight * currentPosition.y - 8.5f, player.transform.position.z);
    }

    public void MoveUp()
    {
        var newPosition = this.currentPosition;
        newPosition.y++;

        SetCurrentPosition(newPosition);
        player.transform.position = new Vector3(roomWidth * currentPosition.x, roomHeight * currentPosition.y - 8.5f, player.transform.position.z);
    }

    public void MoveDown()
    {
        var newPosition = this.currentPosition;
        newPosition.y--;

        SetCurrentPosition(newPosition);
        player.transform.position = new Vector3(roomWidth * currentPosition.x, roomHeight * currentPosition.y - 2f, player.transform.position.z);
    }

    public void SetCurrentPosition(Vector2 newPosition)
    {
        currentPosition = newPosition;
        miniMap.SetCurrentRoom(currentPosition);

        var roomCamera = camera.GetComponent<RoomCamera>();
        roomCamera.SetCurrnetRoom(new Vector2(currentPosition.x, currentPosition.y));
    }
}
