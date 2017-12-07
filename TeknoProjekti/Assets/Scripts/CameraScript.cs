using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    public int spawnWave = 0;
    public EnemySpawn_script enemySpawnScript;

    void Update()
    {

        
        Vector3 setPosition = transform.position;

        if (player.transform.position.x < 6.8f)
        {
            setPosition.x = 0.61f;
        }
           
        if (player.transform.position.x > 6.8f && player.transform.position.x < 19.8f)
        {
            setPosition.x = 13.37f;

            if (spawnWave == 0)
            {
                enemySpawnScript.SpawnWaves();
                spawnWave = 1;
            }

        }
            
        if (player.transform.position.x > 19.8f && player.transform.position.x < 32.8f) 
            setPosition.x = 26.13f; 
        if (player.transform.position.x > 32.8f && player.transform.position.x < 45.8f)
            setPosition.x = 39.5f;
        if (player.transform.position.x > 45.8f && player.transform.position.x < 58.8f)
            setPosition.x = 52.87f;
        if (player.transform.position.x > 58.8f && player.transform.position.x < 71.8f)
            setPosition.x = 66.24f;

        transform.position = setPosition;
    }
 
}
