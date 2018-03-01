using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public List<GameObject> roomPrefabs;
    public int gridSizeX = 4;
    public int gridSizeY = 4;
    public int numberOfRooms = 20;
    public int roomWidth = 18;
    public int roomHeight = 10;
    public GameObject camera;
    private Room[][] rooms;

    private LevelGeneration levelGenerator = new LevelGeneration();
    private GameObject[][] roomInstances;

    public GameObject[][] RoomInstances {
        get
        {
            return roomInstances;
        }
    }

    void Start () {
        //Generate();
    }

    public Room[][] Rooms
    {
        get
        {
            return rooms;
        }
    }

    public void Generate()
    {
        levelGenerator.Generate(new Vector2(gridSizeX, gridSizeY), numberOfRooms);
        rooms = levelGenerator.GetRooms();

        roomInstances = new GameObject[gridSizeY * 2][];

        for (int i = 0; i < gridSizeX * 2; i++)
        {
            roomInstances[i] = new GameObject[gridSizeX * 2];
            for (int j = 0; j < gridSizeY * 2; j++)
            {
                if (rooms[i][j] == null)
                {
                    continue;
                }

                var roomPosition = new Vector2(i * roomHeight, j * roomWidth);
                var convenientPrefabs = roomPrefabs.Where(_ =>
                {
                    var roomScript = _.GetComponent<RoomScript>();
                    var isConvenint = true;
                    var roomBitArray = rooms[i][j].GetBitArray();
                    var prefabBitArray = roomScript.GetBitArray();

                    for(int k = 0; k < roomBitArray.Count; k++)
                    {
                        if (!(prefabBitArray[k] || !roomBitArray[k]))
                        {
                            isConvenint = false;
                            break;
                        }
                    }

                    return isConvenint;
                }).ToList();

                var randomPrefab = convenientPrefabs[Random.Range(0, convenientPrefabs.Count())];
                roomInstances[i][j] = Instantiate(randomPrefab, roomPosition, Quaternion.identity);
                var instanceRoomScript = roomInstances[i][j].GetComponent<RoomScript>();
                instanceRoomScript.ApplyRoomType(rooms[i][j].GetRoomNumber());
            }
        }
    }
}
