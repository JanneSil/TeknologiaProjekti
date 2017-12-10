using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn_script : MonoBehaviour
{
    public PlayerHealthScript playerHealth;
    public GameObject enemy;
    public GameObject BigEnemy;
    public Transform[] spawnPoints;
    public Transform[] spawnPointsWaveTwo;
    public Transform[] spawnPointsWaveThree;
    public CameraScript cameraScript;
    private int spawnPointIndex;

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

        else if (cameraScript.spawnWave == 1)
        {
            StartCoroutine(SpawnWaveThree());
        }

        else if (cameraScript.spawnWave == 2)
        {
            StartCoroutine(SpawnBossWave());
        }
    }

    IEnumerator SpawnWave()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            yield break;
        }

        for (int i = 0; i < 10; i++)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            yield return new WaitForSeconds(1.5f);

        }
    }

    public IEnumerator SpawnWaveTwo()
    {
        yield return new WaitForSeconds(0.5f);

        if (playerHealth.currentHealth <= 0f)
        {
            yield break;
        }

        spawnPointIndex = Random.Range(0, spawnPointsWaveTwo.Length);

        Instantiate(BigEnemy, spawnPointsWaveTwo[spawnPointIndex].position, spawnPointsWaveTwo[spawnPointIndex].rotation);

        for (int i = 0; i < 11; i++)
        {
            spawnPointIndex = Random.Range(0, spawnPointsWaveTwo.Length);
            Instantiate(enemy, spawnPointsWaveTwo[spawnPointIndex].position, spawnPointsWaveTwo[spawnPointIndex].rotation);
            yield return new WaitForSeconds(1.5f);

        }

    }

    public IEnumerator SpawnWaveThree()
    {
        yield return new WaitForSeconds(0.5f);

        if (playerHealth.currentHealth <= 0f)
        {
            yield break;
        }

        spawnPointIndex = Random.Range(0, spawnPointsWaveThree.Length);

        Instantiate(BigEnemy, spawnPointsWaveThree[spawnPointIndex].position, spawnPointsWaveThree[spawnPointIndex].rotation);


        for (int i = 0; i < 12; i++)
        {
            spawnPointIndex = Random.Range(0, spawnPointsWaveThree.Length);
            Instantiate(enemy, spawnPointsWaveThree[spawnPointIndex].position, spawnPointsWaveThree[spawnPointIndex].rotation);
            yield return new WaitForSeconds(1.25f);

        }

        Instantiate(BigEnemy, spawnPointsWaveThree[spawnPointIndex].position, spawnPointsWaveThree[spawnPointIndex].rotation);

    }

    public IEnumerator SpawnBossWave()
    {
        yield return null;
    }
}
