using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    void Start()
    {
        float randomSpawnInterval = Random.Range(2f, 5f);
        InvokeRepeating("SpawnEnemy", 0f, randomSpawnInterval);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-6f, 6f);
        Vector2 spawnPosition = new Vector2(randomX, 5f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
