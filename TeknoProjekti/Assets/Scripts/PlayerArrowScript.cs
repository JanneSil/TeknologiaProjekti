﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowScript : MonoBehaviour
{

    public float Speed;

    public Rigidbody2D rb;

    public float MaxLifeTime = 3f;
    public int ArrowDamage = 20;

    private bool secondHit = false;

    EnemyMeleeScript targetHealth;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, MaxLifeTime);

    }

    void FixedUpdate()
    {
        rb.velocity = transform.right * Speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            targetHealth = other.GetComponent<EnemyMeleeScript>();
            targetHealth.Damage(ArrowDamage);

            if (secondHit)
            {
                Destroy(gameObject);

            }

            secondHit = true;
           // Destroy(gameObject);

        }

       
    }
}
