using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    Transform playerPosition;
    float timer;
    public float timeBetweenPoisonAttacks = 5f;
    public GameObject poisonCloud;

    // Use this for initialization
    void Start ()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //timer += Time.deltaTime;
    }

    public void PoisonAttack()
    {
        

        //if (timer >= timeBetweenPoisonAttacks)
        
            Instantiate(poisonCloud, playerPosition.transform.position, playerPosition.transform.rotation);
            //timer = 0f;

        
    }

    public void TailAttack()
    {

    }
}
