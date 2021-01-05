using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
     [SerializeField] Transform[] enemySpawnPoints;
     [SerializeField] GameObject enemy;
     [SerializeField] float enemySpawnTime = 15f;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, enemySpawnTime);       //repeatly spawn enemy
    }

    private void SpawnEnemy()
    {
        int spawnEnemyPointIndex = Random.Range(0, enemySpawnPoints.Length);
        Instantiate(enemy, enemySpawnPoints[spawnEnemyPointIndex].position, enemySpawnPoints[spawnEnemyPointIndex].rotation);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            {
            Application.Quit();         //allow using esc button to quit
            }
    }
}
