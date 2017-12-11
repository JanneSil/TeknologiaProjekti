using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrowScript : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    public float MaxLifeTime = 3f;
    public int ArrowDamage = 10;

    PlayerHealthScript targetHealth;



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
        //Debug.Log("Collided");

        if (other.tag == "Player")
        {
            targetHealth = other.GetComponent<PlayerHealthScript>();
            targetHealth.TakeDamage(10);
            //Debug.Log("Damage Done");
            Destroy(gameObject);

        }


    }
}
