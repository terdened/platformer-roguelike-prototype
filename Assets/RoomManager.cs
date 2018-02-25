using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {
    public GameObject currentRoom;
    public List<GameObject> rewards;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if(currentRoom != null)
        {
            var roomScript = currentRoom.GetComponent<RoomScript>();

            if(!roomScript.isRewardSpawned && roomScript.isClear)
            {
                var rewardIndex = Random.Range(0, rewards.Count);
                Instantiate(rewards[rewardIndex], currentRoom.transform.position + new Vector3(-3, -9f, 0), Quaternion.identity);
                roomScript.isRewardSpawned = true;
            }
        }
	}
}
