using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public List<string> EnemyTags;

    private StageManager stageManager;

    // Use this for initialization
    void Start () {
        stageManager = GameObject.Find("stage_manager").GetComponent<StageManager>();
    }
	
	public void Spawn()
    {
        var enemyPrefab = stageManager.EnemyPrefabs[Random.Range(0, stageManager.EnemyPrefabs.Count)];
        var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        var room = transform.parent.GetComponent<RoomScript>();
        room.Enemies.Add(enemy);
    }
}
