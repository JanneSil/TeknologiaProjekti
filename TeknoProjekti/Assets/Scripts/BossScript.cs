using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    //Transform playerPosition;
    float timer;
    private Transform player;

    private float timeBetweenPoisonAttacks = 2f;
    private float timeBetweenTailAttacks = 6f;
    private float timeBetweenSlamAttacks = 10f;

    public GameObject poisonCloud;
    public Transform PoisonSpawn;

    private Animator anim;

    private bool poisonAttackDone = false;
    private bool tailAttackDone = false;
    private bool tailSlamDone = false;

    private PlayerHealthScript playerHealth;

    private int DamageValue = 10;
    private int startingHealth = 50;

    public int currentHealth;

    bool dead;

    private AudioSource enemyAudio;



    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        timer = 0;
        currentHealth = startingHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealthScript>();


    }

    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenPoisonAttacks && !poisonAttackDone && !dead)
        {
            poisonAttackDone = true;
            StartCoroutine(PoisonAttack());
        }

        if (timer >= timeBetweenTailAttacks && !tailAttackDone && !dead)
        {
            tailAttackDone = true;
            StartCoroutine(TailAttack());
        }

        if (timer >= timeBetweenSlamAttacks && !tailSlamDone && !dead)
        {
            tailSlamDone = true;
            StartCoroutine(TailSlam());
        }

    }

    IEnumerator PoisonAttack()
    {
        anim.SetTrigger("Spit Attack");

        yield return new WaitForSeconds(1f);

        //playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        Instantiate(poisonCloud, PoisonSpawn.transform.position, PoisonSpawn.transform.rotation);
        yield return null;

        
    }

    IEnumerator TailAttack()
    {
        anim.SetTrigger("Head Attack");

        yield return new WaitForSeconds(1f);

        yield return null;

    }

    IEnumerator TailSlam()
    {
        anim.SetTrigger("Tail Slam");

        yield return new WaitForSeconds(1f);

        timer = 0f;
        poisonAttackDone = false;
        tailSlamDone = false;
        tailAttackDone = false;

        yield return null;

    }

    public void Damage(int amount)
    {
        currentHealth -= amount;
        //enemyAudio.clip = enemyDamageClip;
        //enemyAudio.Play();

        if (currentHealth <= 0 && !dead)
        {
            Death();
        }
    }

    public void Death()
    {
        dead = true;
        anim.SetBool("isDead", true);

        //colliderOne.enabled = false;
        //colliderTwo.enabled = false;

        //sprite.sortingOrder = sortingOrder;

        //sprite.sortingLayerName = LAYER_NAME;


    }
}
