using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{

    public float speed;
    public GameObject playerRangePos;
    public GameObject playerRangePosTwo;
    private Animator anim;

    public GameObject playerArrow;
    private float moveVertical;
    private float moveHorizontal;
    public GameObject enemy;
    private bool inRange;

    EnemyMeleeScript targetHealth;

    public float timeBetweenAttacks = 0.5f;
    float timer;
    float attackTimer;

    bool facingRight = true;
    bool isWalking = false;

    private AudioSource playerAudio;
    public AudioSource playerWalkAudio;

    public AudioClip playerRangeClip;
    public AudioClip playerMeleeClip;
    public AudioClip playerWalkClip;
    

    private SpriteRenderer spriteRenderer;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");

       
        
            transform.Translate(0, 1 * moveVertical * speed * Time.deltaTime, 0);
            transform.Translate(1 * moveHorizontal * speed * Time.deltaTime, 0, 0);
        
 

        Walking();
            

    }
    void FixedUpdate()
    {

        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
            spriteRenderer.flipX = false;
        }

        else if (moveHorizontal < 0 && facingRight)
        {
            Flip();
            spriteRenderer.flipX = true;
        }

        timer += Time.deltaTime;
        

        if (Input.GetButton("Fire1") && timer >= timeBetweenAttacks)
        {
            //Play Animation
            anim.SetTrigger("Attack");
            //Play Sound
            playerAudio.clip = playerMeleeClip;
            playerAudio.Play();
           

            if (inRange)
            {
                // Do damage;
                //EnemyMeleeScript targetHealth = targetRigidbody.GetComponent<TankHealth>();
                Debug.Log("Did damage");
                targetHealth.Damage(10);
            }

            timer = 0f;
        }

        if (Input.GetButton("Fire2") && timer >= timeBetweenAttacks)
        {
            playerAudio.clip = playerRangeClip;
            playerAudio.Play();

            if (facingRight)
            {
                anim.SetTrigger("Shoot");
                Instantiate(playerArrow, playerRangePos.transform.position, playerRangePos.transform.rotation);
                
            }
            else if (!facingRight)
            {
                Instantiate(playerArrow, playerRangePosTwo.transform.position, playerRangePosTwo.transform.rotation);
                anim.SetTrigger("Shoot");
            }

            timer = 0f;
        }

    }


    void Walking()
    {
        if (moveVertical != 0 || moveHorizontal != 0)
        {
            anim.SetBool("Walking", true);

            if (isWalking == false)
            {
                playerWalkAudio.clip = playerWalkClip;
                playerWalkAudio.Play();
                isWalking = true;
            }

        }
        else
        {
            anim.SetBool("Walking", false);
            isWalking = false;
            playerWalkAudio.Stop();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            inRange = true;
            Debug.Log("inRange");
            targetHealth = other.GetComponent<EnemyMeleeScript>();
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            inRange = false;
            targetHealth = null;
        }
    }
}