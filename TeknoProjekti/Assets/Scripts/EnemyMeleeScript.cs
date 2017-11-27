using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeScript : MonoBehaviour
{
    public float speed = 1.0f;
    private Transform player;
    private float minDistance = 0.6f;
    private float distanceToTarget;
    public PlayerHealthScript playerHealth;
   
    public float hitRate = 2f;
    public float nextHit = 0f;

    public Rigidbody2D ribo;
   

    public int startingHealth = 50;
    public int currentHealth;

    bool dead;

    void Awake()
    {
        currentHealth = startingHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ribo = GetComponent<Rigidbody2D>();
        playerHealth = player.GetComponent<PlayerHealthScript>();
    }
    
    /*void Start()
    {

    }*/

    
    void Update()
    {
        distanceToTarget = Vector2.Distance(transform.position, player.position);

        if(distanceToTarget > minDistance && !dead)
        {
            transform.position = (Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
        }
        
        if(distanceToTarget <= minDistance && Time.time > nextHit)
        {
            nextHit = Time.time + hitRate;
            Attack();
        }

    }

    void FixedUpdate()
    {
        
    }

    public void Attack()
    {
        Debug.Log("Enemy did damage.");
        playerHealth.TakeDamage(10);
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0 && !dead)
        {
            Death();
        }
    }

    public void Death()
    {
        dead = true;

        //GetComponent<EnemyMeleeScript>().enabled = false;

    }
}
