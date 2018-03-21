using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    private StageManager stageManager;
    public List<string> enemyTags;
	
    // Use this for initialization
	void Start () {
        stageManager = GameObject.Find("stage_manager").GetComponent<StageManager>();
    }
	
	public void Spawn()
    {
        var enemyPrefab = stageManager.enemyPrefabs[Random.Range(0, stageManager.enemyPrefabs.Count)];
        var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        var room = transform.parent.GetComponent<RoomScript>();
        room.enemies.Add(enemy);
    }
}
