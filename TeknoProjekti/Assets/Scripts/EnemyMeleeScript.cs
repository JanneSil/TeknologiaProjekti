﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeScript : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform target;
    private float minDistance = 0.6f;
    private float distanceToTarget;

    public Rigidbody2D ribo;
   

    public int startingHealth = 50;
    public int currentHealth;

    bool dead;

    void Awake()
    {
        currentHealth = startingHealth;

        ribo = GetComponent<Rigidbody2D>();
    }
    
    /*void Start()
    {

    }*/

    
    void Update()
    {
        distanceToTarget = Vector2.Distance(transform.position, target.position);

        if(distanceToTarget > minDistance)
        {
            transform.position = (Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime));
        }
        if (currentHealth <= 0 && !dead)
        {
            Death();
        }

    }

    void FixedUpdate()
    {
        
    }

    public void Attack()
    {

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

        

    }
}