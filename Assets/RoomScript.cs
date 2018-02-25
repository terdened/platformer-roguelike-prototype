using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour {
    public bool isClear;
    public bool isRewardSpawned;
    public List<GameObject> enemies;

	// Use this for initialization
	void Start () {
        isClear = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!isClear && enemies.Count == 0)
            isClear = true;
	}
}
