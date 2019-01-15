using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    private EnemySpawn[] enemySpawns;

    public List<GameObject> enemies;

    private float enemySpawnDelayInSeconds;

    
    public List<GameObject> remainingEnemies;

    private bool canSpawnEnemy;

    private WaveManager waveManager;

	// Use this for initialization
	void Start () {
        enemySpawns = FindObjectsOfType<EnemySpawn>();
        canSpawnEnemy = true;

        waveManager = GetComponent<WaveManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!canSpawnEnemy) return;
        enemySpawnDelayInSeconds = Random.Range(0.5f, 2f);

        SpawnEnemy();

        StartCoroutine(SpawnCooldown());
	}

    private void SpawnEnemy()
    {
        if (enemySpawns.Length == 0 || enemies.Count == 0 || remainingEnemies.Count == 0) return;

        int index = Random.Range(0, remainingEnemies.Count -1);

        GameObject enemyObject = remainingEnemies[index];

        int i = Random.Range(0, enemySpawns.Length);

        enemySpawns[i].Spawn(enemyObject);

        remainingEnemies.Remove(enemyObject);

    }

    private IEnumerator SpawnCooldown()
    {
        canSpawnEnemy = false;
        yield return new WaitForSeconds(enemySpawnDelayInSeconds);
        canSpawnEnemy = true;
    }
}