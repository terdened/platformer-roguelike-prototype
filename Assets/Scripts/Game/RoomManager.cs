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

            if(!roomScript.IsEnemySpawned)
            {
                CurrentRoom.GetComponentsInChildren<EnemySpawn>().ToList().ForEach(_ => _.Spawn());
                roomScript.IsEnemySpawned = true;
            }

            roomScript.UpdateRoom();

            if (!roomScript.IsRewardSpawned && roomScript.IsClear)
            {
                var rewardIndex = Random.Range(0, Rewards.Count);
                Instantiate(Rewards[rewardIndex], CurrentRoom.transform.position + new Vector3(-3, -9f, 0), Quaternion.identity);
                roomScript.IsRewardSpawned = true;
            }

            CurrentRoom.GetComponentsInChildren<Door>().ToList().ForEach(_ => _.IsOpen = roomScript.IsClear);
        }
	}
}
