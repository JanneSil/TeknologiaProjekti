using System.Collections;
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
    EnemyRangedScript enemyHealth;
    BossScript bossHealth;

    

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

        else if (other.tag == "Ranged")
        {
            enemyHealth = other.GetComponent<EnemyRangedScript>();
            enemyHealth.Damage(ArrowDamage);

            if (secondHit)
            {
                Destroy(gameObject);

            }

            secondHit = true;

        }

        else if (other.tag == "Boss")
        {
            bossHealth = other.GetComponent<BossScript>();
            bossHealth.Damage(ArrowDamage);

            if (secondHit)
            {
                Destroy(gameObject);

            }

            secondHit = true;

        }


    }
}
