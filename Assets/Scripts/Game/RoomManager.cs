using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomManager : MonoBehaviour {
    public GameObject CurrentRoom;
    public List<GameObject> Rewards;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if(CurrentRoom != null)
        {
            var roomScript = CurrentRoom.GetComponent<RoomScript>();

            if(!roomScript.isEnemySpawned)
            {
                CurrentRoom.GetComponentsInChildren<EnemySpawn>().ToList().ForEach(_ => _.Spawn());
                roomScript.isEnemySpawned = true;
            }

            roomScript.UpdateRoom();

            if (!roomScript.isRewardSpawned && roomScript.isClear)
            {
                var rewardIndex = Random.Range(0, Rewards.Count);
                Instantiate(Rewards[rewardIndex], CurrentRoom.transform.position + new Vector3(-3, -9f, 0), Quaternion.identity);
                roomScript.isRewardSpawned = true;
            }

            CurrentRoom.GetComponentsInChildren<Door>().ToList().ForEach(_ => _.IsOpen = roomScript.isClear);
        }
	}
}
