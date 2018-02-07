using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public GameObject[] roomPrefabs;
    public int gridSizeX = 4;
    public int gridSizeY = 4;
    public int numberOfRooms = 20;
    public int roomWidth = 18;
    public int roomHeight = 10;
    public GameObject camera;

    private LevelGeneration levelGenerator = new LevelGeneration();
    private GameObject[][] roomInstances;

    void Start () {
        Generate();
    }


    void Generate()
    {
        levelGenerator.Generate(new Vector2(gridSizeX, gridSizeY), numberOfRooms);
        var rooms = levelGenerator.GetRooms();

        roomInstances = new GameObject[gridSizeY * 2][];

        for (int i = 0; i < gridSizeX * 2; i++)
        {
            roomInstances[i] = new GameObject[gridSizeX * 2];
            for (int j = 0; j < gridSizeY * 2; j++)
            {
                if (rooms[i, j] == null)
                {
                    continue;
                }

                var roomPosition = new Vector2(i * roomHeight, j * roomWidth);
                roomInstances[i][j] = Instantiate(roomPrefabs[rooms[i,j].GetRoomNumber()], roomPosition, Quaternion.identity);

                if(rooms[i, j].type == 1)
                {
                    var roomCamera = (RoomCamera)camera.GetComponent<RoomCamera>();
                    roomCamera.SetCurrnetRoom(new Vector2(i, j));
                }
            }
        }
    }
}
