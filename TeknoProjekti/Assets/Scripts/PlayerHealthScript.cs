using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour {

    public int startingHealth = 100;                           
    public int currentHealth;                                   
                                                              
    PlayerMovementScript playerMovement;                              

    bool isDead;                                                                                           


    void Awake()
    {
        playerMovement = GetComponent<PlayerMovementScript>();

        currentHealth = startingHealth;
    }


    void Update()
    {

    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        //Slider change here

        //Play audio here

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        //Play animation

        //Play audio

        playerMovement.enabled = false;
    }
}
