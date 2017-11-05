using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrowScript : MonoBehaviour
{

    public float speed;

    public Rigidbody2D rb;

    public float MaxLifeTime = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, MaxLifeTime);

    }

    void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }
}
