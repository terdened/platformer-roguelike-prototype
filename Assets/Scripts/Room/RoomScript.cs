using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour {
    public bool IsClear;
    public bool IsRewardSpawned;
    public bool IsEnemySpawned;
    public List<GameObject> Enemies;
    public int Type;

	// Use this for initialization
	void Start () {
        IsClear = false;
        Enemies = new List<GameObject>();
    }
	
	public void UpdateRoom () {
        Enemies.RemoveAll(_ => _ == null);
        if (!IsClear && Enemies.Count == 0)
            IsClear = true;
	}

    public List<bool> GetBitArray()
    {
        var result = new List<bool>();
        
        string binary = Convert.ToString(Type, 2);

        while (binary.Length < 4)
            binary = "0" + binary;

        for(int i = 0; i < binary.Length; i++)
        {
            result.Add(Convert.ToBoolean(Convert.ToInt32(binary.Substring(i, 1))));
        }

        return result;
    }

    public void ApplyRoomType(int roomType)
    {
        var result = new List<bool>();

        string binary = Convert.ToString(roomType, 2);

        while (binary.Length < 4)
            binary = "0" + binary;

        if(binary.Substring(0,1) == "0")
        {
            var door_left = transform.Find("door_left");

            if (door_left != null)
                Destroy(door_left.gameObject);
        }

        if (binary.Substring(1, 1) == "0")
        {
            var door_down = transform.Find("door_down");

            if (door_down != null)
                Destroy(door_down.gameObject);
        }

        if (binary.Substring(2, 1) == "0")
        {
            var door_right = transform.Find("door_right");

            if (door_right != null)
                Destroy(door_right.gameObject);
        }

        if (binary.Substring(3, 1) == "0")
        {
            var door_up = transform.Find("door_up");

            if (door_up != null)
                Destroy(door_up.gameObject);
        }
    }
}
