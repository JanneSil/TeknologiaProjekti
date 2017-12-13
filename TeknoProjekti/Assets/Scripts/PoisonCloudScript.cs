using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloudScript : MonoBehaviour {

    PlayerHealthScript targetHealth;
    bool TakingDamage;

    Transform playerPosition;

    float timer;
    public float poisonTickTime = 0.5f;
    float cloudLifeTime = 5f;
    private float speed = 3;
    private Vector2 position;


    // Use this for initialization
    void Start ()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        position = new Vector2(playerPosition.position.x, playerPosition.position.y);

    }

    // Update is called once per frame
    void Update ()
    {
        transform.position = (Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime));

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
