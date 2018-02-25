using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour {
    public GameObject roomPrfab;
    private Room[][] rooms;
    private Vector2 currentRoom;
    private GameObject[][] roomInstances;

    public void SetRooms(Room[][] newRooms)
    {
        this.rooms = newRooms;
    }

    public void SetCurrentRoom(Vector2 newCurrentRoom)
    {
        this.currentRoom = newCurrentRoom;
        for (int i = 0; i < rooms.Length; i++)
        {
            for (int j = 0; j < rooms[i].Length; j++)
            {
                if (rooms[i][j] == null)
                    continue;

                var mapper = rooms[i][j];
                if (i == this.currentRoom.x && j == this.currentRoom.y)
                    mapper.type = 1;
                else
                    mapper.type = 0;
            }   
        }

        DestroyRooms();
        DrawMap();
    }

    public void DestroyRooms()
    {
        if (roomInstances == null)
            return;

        for (int i = 0; i < roomInstances.Length; i++)
        {
            for (int j = 0; j < roomInstances[i].Length; j++)
            {
                Destroy(roomInstances[i][j]);
            }
        }
        roomInstances = null;
    }

    public void DrawMap()
    {
        roomInstances = new GameObject[rooms.Length][];
        for (int i = 0; i < rooms.Length; i++)
        {
            roomInstances[i] = new GameObject[rooms[i].Length];
            for (int j = 0; j < rooms[i].Length; j++)
            {
                if (rooms[i][j] == null)
                    continue; //skip where there is no room

                Vector2 drawPos = rooms[i][j].gridPos;
                drawPos.x *= 0.8f;//aspect ratio of map sprite
                drawPos.y *= 0.4f;
                drawPos.x += 5.75f + gameObject.transform.position.x;
                drawPos.y += 3.3f + gameObject.transform.position.y;

                //create map obj and assign its variables
                var roomInstance = Instantiate(roomPrfab, drawPos, Quaternion.identity);
                MapSpriteSelector mapper = roomInstance.GetComponent<MapSpriteSelector>();
                mapper.transform.parent = gameObject.transform;
                mapper.type = rooms[i][j].type;
                mapper.up = rooms[i][j].doorTop;
                mapper.down = rooms[i][j].doorBot;
                mapper.right = rooms[i][j].doorRight;
                mapper.left = rooms[i][j].doorLeft;
                roomInstances[i][j] = roomInstance;
            }
        }
    }
}
