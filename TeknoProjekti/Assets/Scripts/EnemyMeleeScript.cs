using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeScript : MonoBehaviour
{
    public float speed = 1.0f;
    private Transform player;
    private float minDistance = 1.4f;
    private float distanceToTarget;
    private PlayerHealthScript playerHealth;
   
    public float hitRate = 2f;
    public float nextHit = 0f;

    public Rigidbody2D ribo;
    private Animator anim;

    private Collider2D colliderOne;
    public Collider2D colliderTwo;


    public int startingHealth = 50;
    public int currentHealth;

    public const string LAYER_NAME = "Dead";

    public int sortingOrder = 0;
    private SpriteRenderer sprite;

    bool dead;

    private AudioSource enemyAudio;
    public AudioClip enemyWalkingClip;

    void Awake()
    {
        currentHealth = startingHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ribo = GetComponent<Rigidbody2D>();
        playerHealth = player.GetComponent<PlayerHealthScript>();
        anim = GetComponent<Animator>();
        colliderOne = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        enemyAudio = GetComponent<AudioSource>();
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
            anim.SetBool("Walking", true);
        }
        
        if(distanceToTarget <= minDistance && Time.time > nextHit && !dead)
        {
            nextHit = Time.time + hitRate;
            anim.SetBool("Walking", false);
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
        anim.SetTrigger("Attacking");

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
        anim.SetBool("isDead", true);

        colliderOne.enabled = false;
        colliderTwo.enabled = false;

        sprite.sortingOrder = sortingOrder;

        sprite.sortingLayerName = LAYER_NAME;

        //GetComponent<EnemyMeleeScript>().enabled = false;

    }
}
