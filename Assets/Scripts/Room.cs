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
            binaryResult += 1000;
        
        if (doorRight)
            binaryResult += 100;
        
        if (doorBot)
            binaryResult += 10;
        
        if (doorLeft)
            binaryResult += 1;
        
        return Convert.ToInt32(binaryResult.ToString(), 2);
    }
}
