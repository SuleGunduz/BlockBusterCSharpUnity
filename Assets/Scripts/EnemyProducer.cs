using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProducer : MonoBehaviour {

    public bool shouldSpawn;
    public Enemy[] enemyPrefabs;
    public float[] moveSpeedRange;
    public int[] healthRange;

    private Bounds spawnArea;//???? bounds
    private GameObject player;

    public void SpawnEnemies(bool shouldSpawn)
    {
        if (shouldSpawn)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        this.shouldSpawn = shouldSpawn;//?????????
    }

    void Start()
    {
        spawnArea = this.GetComponent<BoxCollider>().bounds;//????
        SpawnEnemies(shouldSpawn);
        InvokeRepeating("spawnEnemy", 0.5f, 1.0f);//0.5 saniye de bir tekrarla mı?
    }

    Vector3 randomSpawnPosition()
    {
        float x = Random.Range(spawnArea.min.x, spawnArea.max.x);
        float z = Random.Range(spawnArea.min.z, spawnArea.max.z);
        float y = 0.5f;

        return new Vector3(x, y, z);
    }

    void spawnEnemy()
    {
        if (shouldSpawn == false || player == null)
        {
            return;
        }
        //bundan sonrasını anlamadım????
        int index = Random.Range(0, enemyPrefabs.Length);
        var newEnemy = Instantiate(enemyPrefabs[index], randomSpawnPosition(), Quaternion.identity) as Enemy;
        newEnemy.Initialize(player.transform,
            Random.Range(moveSpeedRange[0], moveSpeedRange[1]),
            Random.Range(healthRange[0], healthRange[1]));
    }
}
