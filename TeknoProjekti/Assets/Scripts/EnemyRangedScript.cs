﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedScript : MonoBehaviour
{
    public float speed = 1.0f;
    private Transform player;
    private float minDistance = 1f;
    private float distanceToTarget;
    private PlayerHealthScript playerHealth;
    public GameObject enemyArrow;
    public Transform EnemyRangePos;
    public Transform EnemyRangePosTwo;


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
    public AudioClip EnemyBowClip;
    public AudioClip EnemyDamageClip;




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

        if (distanceToTarget > minDistance && !dead && playerHealth.isDead == false)
        {
            transform.position = (Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));

            anim.SetBool("Walking", true);
        }

        if (distanceToTarget <= 7f && Time.time > nextHit && !dead && playerHealth.isDead == false)
        {
            transform.position = (Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
            nextHit = Time.time + hitRate;
            anim.SetBool("Walking", false);
            StartCoroutine(Attack());
        }

        if (transform.position.x >= player.position.x && !dead)
        {
            sprite.flipX = false;
        }

        if (transform.position.x < player.position.x && !dead)
        {
            sprite.flipX = true;
        }

    }

    void FixedUpdate()
    {

    }

    IEnumerator Attack()
    {
        enemyAudio.clip = EnemyBowClip;
        enemyAudio.Play();
        yield return new WaitForSeconds(0.2f);


        if (transform.position.x >= player.position.x && !dead)
        {

            anim.SetTrigger("Attacking");
            Instantiate(enemyArrow, EnemyRangePos.transform.position, EnemyRangePos.transform.rotation);
            yield return null;

        }
        else if (transform.position.x < player.position.x && !dead)
        {
            Instantiate(enemyArrow, EnemyRangePosTwo.transform.position, EnemyRangePosTwo.transform.rotation);
            anim.SetTrigger("Attacking");
            yield return null;
        }

        yield return null;


    }

    public void Damage(int amount)
    {
        currentHealth -= amount;
        enemyAudio.clip = EnemyDamageClip;
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
