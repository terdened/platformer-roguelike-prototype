using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public List<GameObject> RoomPrefabs;
    public int GridSizeX = 4;
    public int GridSizeY = 4;
    public int NumberOfRooms = 20;

    private int roomWidth = 10;
    private int roomHeight = 18;
    private Room[][] rooms;
    private LevelGeneration levelGenerator = new LevelGeneration();
    private GameObject[][] roomInstances;

    public GameObject[][] RoomInstances {
        get
        {
            return roomInstances;
        }
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
        levelGenerator.Generate(new Vector2(GridSizeX, GridSizeY), NumberOfRooms);
        rooms = levelGenerator.GetRooms();

        roomInstances = new GameObject[GridSizeY * 2][];

        for (int i = 0; i < GridSizeX * 2; i++)
        {
            roomInstances[i] = new GameObject[GridSizeX * 2];
            for (int j = 0; j < GridSizeY * 2; j++)
            {
                if (rooms[i][j] == null)
                {
                    continue;
                }

                var roomPosition = new Vector2(i * roomHeight, j * roomWidth);
                var convenientPrefabs = RoomPrefabs.Where(_ =>
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
