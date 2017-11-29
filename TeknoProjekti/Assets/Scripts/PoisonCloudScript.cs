using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloudScript : MonoBehaviour {

    PlayerHealthScript targetHealth;
    bool TakingDamage;

    float timer;
    public float poisonTickTime = 0.5f;
    float cloudLifeTime = 5f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if (TakingDamage && timer >= poisonTickTime)
        {
            targetHealth.TakeDamage(5);
            Debug.Log("Taking damage");
            timer = 0;
        }

        Destroy(gameObject, cloudLifeTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TakingDamage = true;
            targetHealth = other.GetComponent<PlayerHealthScript>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TakingDamage = false;
        }
    }
}
