using System;
using System.Collections.Generic;
using UnityEngine;

public class Room {
	public Vector2 GridPos;
	public int Type;
	public bool DoorTop;
    public bool DoorBot;
    public bool DoorLeft;
    public bool DoorRight;

    public Room(Vector2 gridPos, int type){
        GridPos = gridPos;
        Type = type;
	}

    public int GetRoomNumber()
    {
        int binaryResult = 0;

        if (DoorTop)
            binaryResult += 1;
        
        if (DoorRight)
            binaryResult += 10;
        
        if (DoorBot)
            binaryResult += 100;
        
        if (DoorLeft)
            binaryResult += 1000;

        return Convert.ToInt32(binaryResult.ToString(), 2);
    }

    public List<bool> GetBitArray()
    {
        var result = new List<bool>();

        result.Add(DoorLeft);
        result.Add(DoorBot);
        result.Add(DoorRight);
        result.Add(DoorTop);

        return result;
    }
}
