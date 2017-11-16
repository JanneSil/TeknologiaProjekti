﻿using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{

    public float speed;
    public GameObject playerRangePos;
    public GameObject playerRangePosTwo;

    public GameObject playerArrow;
    private float moveVertical;
    private float moveHorizontal;
    GameObject enemy;
    private bool inRange;

    public float timeBetweenAttacks = 0.5f;
    float timer;

    bool facingRight = true;


    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");

        transform.Translate(0, 1 * moveVertical * speed * Time.deltaTime, 0);
        transform.Translate(1 * moveHorizontal * speed * Time.deltaTime, 0, 0);

    }
    void FixedUpdate()
    {

        if (moveHorizontal > 0 && !facingRight)
            Flip();
        else if (moveHorizontal < 0 && facingRight)
            Flip();

        timer += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            //Play Animation
            //Play Sound
            if (inRange)
            {
                // Do damage;
            }
        }

        if (Input.GetButton("Fire2") && timer >= timeBetweenAttacks)
        {
            //Animation
            //Sound
            if (facingRight)
                Instantiate(playerArrow, playerRangePos.transform.position, playerRangePos.transform.rotation);
            else if (!facingRight)
                Instantiate(playerArrow, playerRangePosTwo.transform.position, playerRangePosTwo.transform.rotation);

            timer = 0f;
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == enemy)
        {
            inRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject == enemy)
        {
            inRange = false;
        }
    }
}