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
    public int DamageValue = 10;

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
    private SpriteRenderer spriteRenderer;


    [SerializeField]
    private AudioClip enemyWalkingClip, enemySlashClip, enemyDamageClip;

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
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /*void Start()
    {

    }*/


    void Update()
    {
        distanceToTarget = Vector2.Distance(transform.position, player.position);

        if(transform.position.x >= player.position.x && !dead)
        {
            spriteRenderer.flipX = false;
        }

        if (transform.position.x < player.position.x && !dead)
        {
            spriteRenderer.flipX = true;
        }

        if (distanceToTarget > minDistance && !dead && playerHealth.isDead == false)
        {
            transform.position = (Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
            anim.SetBool("Walking", true);
        }
        
        if(distanceToTarget <= minDistance && Time.time > nextHit && !dead && playerHealth.isDead == false)
        {
            nextHit = Time.time + hitRate;
            anim.SetBool("Walking", false);
            anim.SetTrigger("Attacking");
            enemyAudio.clip = enemySlashClip;
            enemyAudio.Play();
            StartCoroutine(EnemyAttack());
        }

        if(playerHealth.isDead == true)
        {
            anim.SetBool("Walking", false);

        }

    }

    void FixedUpdate()
    {
        
    }


    IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(0.4f);

        if (distanceToTarget <= minDistance && !dead)
        {
            playerHealth.TakeDamage(DamageValue);
        }
        
        yield return null;
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;
        enemyAudio.clip = enemyDamageClip;
        enemyAudio.Play();

        if (currentHealth <= 0 && !dead)
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
