using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {
    public Vector2 CurrentPosition;
    public GameObject Camera;
    public GameObject Player;
    public GameObject LevelBuilderPrefab;
    public List<GameObject> EnemyPrefabs;
    
    private int roomWidth = 18;
    private int roomHeight = 10;
    private GameObject[][] roomInstances;
    private MinimapScript miniMap;

    // Use this for initialization
    void Start () {
        var levelBuilder = LevelBuilderPrefab.GetComponent<LevelBuilder>();
        miniMap = GameObject.Find("mini_map").GetComponent<MinimapScript>();

        levelBuilder.Generate();
        roomInstances = levelBuilder.RoomInstances;

        miniMap.SetRooms(levelBuilder.Rooms);

        SetCurrentPosition(new Vector2(4, 4));
        Player.transform.position = new Vector3(roomWidth * CurrentPosition.x, roomHeight * CurrentPosition.y - 2, Player.transform.position.z);
    }

    public void MoveRight()
    {
        var newPosition = this.CurrentPosition;
        newPosition.x++;

        SetCurrentPosition(newPosition);
        Player.transform.position = new Vector3(roomWidth * CurrentPosition.x - 7.5f, roomHeight * CurrentPosition.y - 8.5f, Player.transform.position.z);
    }

    public void MoveLeft()
    {
        var newPosition = this.CurrentPosition;
        newPosition.x--;

        SetCurrentPosition(newPosition);
        Player.transform.position = new Vector3(roomWidth * CurrentPosition.x + 7.5f, roomHeight * CurrentPosition.y - 8.5f, Player.transform.position.z);
    }

    public void MoveUp()
    {
        var newPosition = this.CurrentPosition;
        newPosition.y++;

        SetCurrentPosition(newPosition);
        Player.transform.position = new Vector3(roomWidth * CurrentPosition.x, roomHeight * CurrentPosition.y - 8.5f, Player.transform.position.z);
    }

    public void MoveDown()
    {
        var newPosition = this.CurrentPosition;
        newPosition.y--;

        SetCurrentPosition(newPosition);
        Player.transform.position = new Vector3(roomWidth * CurrentPosition.x, roomHeight * CurrentPosition.y - 2f, Player.transform.position.z);
    }

    public void SetCurrentPosition(Vector2 newPosition)
    {
        CurrentPosition = newPosition;
        miniMap.SetCurrentRoom(CurrentPosition);

        var roomCamera = Camera.GetComponent<RoomCamera>();
        roomCamera.SetCurrnetRoom(new Vector2(CurrentPosition.x, CurrentPosition.y));


        var roomManager = GameObject.Find("room_manager").GetComponent<RoomManager>();
        roomManager.CurrentRoom = roomInstances[Mathf.RoundToInt(newPosition.x)][Mathf.RoundToInt(newPosition.y)];
    }
}
