using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour {

    public int startingHealth = 100;                           
    public int currentHealth;                                   
                                                              
    PlayerMovementScript playerMovement;
    private Animator anim;


    bool isDead;                                                                                           


    void Awake()
    {
        playerMovement = GetComponent<PlayerMovementScript>();

        currentHealth = startingHealth;

        anim = GetComponent<Animator>();

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

        anim.SetBool("isDead", true);

        //Play audio

        playerMovement.enabled = false;
    }
}
