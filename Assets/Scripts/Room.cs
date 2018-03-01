using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room {
	public Vector2 gridPos;
	public int type;
	public bool doorTop, doorBot, doorLeft, doorRight;
	public Room(Vector2 _gridPos, int _type){
		gridPos = _gridPos;
		type = _type;
	}

    public int GetRoomNumber()
    {
        int binaryResult = 0;

        if (doorTop)
            binaryResult += 1;
        
        if (doorRight)
            binaryResult += 10;
        
        if (doorBot)
            binaryResult += 100;
        
        if (doorLeft)
            binaryResult += 1000;

        return Convert.ToInt32(binaryResult.ToString(), 2);
    }

    public List<bool> GetBitArray()
    {
        var result = new List<bool>();

        result.Add(doorLeft);
        result.Add(doorBot);
        result.Add(doorRight);
        result.Add(doorTop);

        return result;
    }
}
