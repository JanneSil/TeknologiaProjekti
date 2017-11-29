using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowScript : MonoBehaviour
{

    public float speed;

    public Rigidbody2D rb;

    public float MaxLifeTime = 3f;
    EnemyMeleeScript targetHealth;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, MaxLifeTime);

    }

    void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided");

        if (other.tag == "Enemy")
        {
            targetHealth = other.GetComponent<EnemyMeleeScript>();
            targetHealth.Damage(10);
            Debug.Log("Damage Done");
            Destroy(gameObject);

        }

       
    }
}
