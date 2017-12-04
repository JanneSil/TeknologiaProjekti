using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour {

    public int startingHealth = 100;                           
    public int currentHealth;                                   
                                                              
    PlayerMovementScript playerMovement;
    private Animator anim;
    public Slider healthSlider;

    private AudioSource playerAudio;
    public AudioSource playerWalkAudio;

    public AudioClip playerDeathClip;
    public AudioClip playerHitClip;

   public bool isDead;                                                                                           


    void Awake()
    {
        playerMovement = GetComponent<PlayerMovementScript>();

        currentHealth = startingHealth;

        playerAudio = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();

        healthSlider.value = currentHealth;

    }


    void Update()
    {

    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        //Slider change here
        healthSlider.value = currentHealth;

        //Play audio here
        playerAudio.clip = playerHitClip;

        if(!isDead)
            playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        playerAudio.clip = playerDeathClip;
        playerAudio.Play();
        playerWalkAudio.Stop();
        isDead = true;

        anim.SetBool("isDead", true);

        //Play audio

        playerMovement.enabled = false;
    }
}
