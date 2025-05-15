using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Wave
{
    public string waveName;
    public int noOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;

    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemyMelee = GameObject.FindGameObjectsWithTag("EnemyMelee");
        GameObject[] totalEnemyFlying = GameObject.FindGameObjectsWithTag("EnemyFlying");
        GameObject[] totalEnemyRanged = GameObject.FindGameObjectsWithTag("EnemyRanged");
        if (totalEnemyMelee.Length == 0 && totalEnemyFlying.Length == 0 && totalEnemyRanged.Length == 0 && !canSpawn && currentWaveNumber+1 != waves.Length)
        {
            currentWaveNumber++;
            canSpawn = true;
        }

        NextLevel();
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if (currentWave.noOfEnemies == 0)
            {
                canSpawn = false;
            }
        }
    }

    void NextLevel()
    {
        if (currentWave.noOfEnemies == 0 && currentWaveNumber == 5)
        {
            SceneManager.LoadSceneAsync(2);
        }
    }
}
