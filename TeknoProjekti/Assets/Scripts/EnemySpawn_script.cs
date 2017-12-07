using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn_script : MonoBehaviour
{
    public PlayerHealthScript playerHealth;
    public GameObject enemy;
    public Transform[] spawnPoints;
    public CameraScript cameraScript;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    public void SpawnWaves()
    {
        if (cameraScript.spawnWave == 0)
        {
            StartCoroutine(SpawnWaveTwo());
        }
    }

    IEnumerator SpawnWave()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            yield break;
        }

        for (int i = 0; i < 5; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            yield return new WaitForSeconds(3);

        }
    }

    public IEnumerator SpawnWaveTwo()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            yield break;
        }

        for (int i = 0; i < 8; i++)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            yield return new WaitForSeconds(2.5f);

        }
    }

}
