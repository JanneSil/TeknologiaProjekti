using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovementScript : MonoBehaviour
{

    public float speed;
    public GameObject playerRangePos;
    public GameObject playerRangePosTwo;
    public GameObject ColliderOne;
    public GameObject ColliderTwo;

    private Animator anim;
    public Text ArrowCountText;
    private int arrowCount = 10;

    public GameObject playerArrow;
    private float moveVertical;
    private float moveHorizontal;
    public GameObject enemy;
    private bool inRange;
    public int SlashDamage;

    EnemyMeleeScript targetHealth;
    PlayerColliderScript colliderScript;

    public float timeBetweenAttacks = 0.5f;
    float timer;
    float attackTimer;

    bool facingRight = true;
    bool isWalking = false;

    private AudioSource playerAudio;
    public AudioSource playerWalkAudio;

    [SerializeField]
    private AudioClip playerRangeClip;
    public AudioClip playerMeleeClip;
    public AudioClip playerWalkClip;
    

    private SpriteRenderer spriteRenderer;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ArrowCountText.text = "Arrows: " + arrowCount;

    }

    void Update()
    {
            

    }
    void FixedUpdate()
    {
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");

        transform.Translate(0, 1 * moveVertical * speed * Time.deltaTime, 0);
        transform.Translate(1 * moveHorizontal * speed * Time.deltaTime, 0, 0);

        Walking();

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
            anim.SetTrigger("Attack");
            playerAudio.clip = playerMeleeClip;
            playerAudio.Play();
            timer = 0f;

            if (facingRight)
            {
                StartCoroutine(PlayerSwordAttackRight());
            }

            else if (!facingRight)
            {
                StartCoroutine(PlayerSwordAttackLeft());
            }
        }

        if (Input.GetButton("Fire2") && timer >= timeBetweenAttacks && arrowCount > 0)
        {
            playerAudio.clip = playerRangeClip;
            playerAudio.Play();
            arrowCount -= 1;
            ArrowCountText.text = "Arrows: " + arrowCount;

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

    IEnumerator PlayerSwordAttackRight()
    {

        yield return new WaitForSeconds(0.3f);
        colliderScript = ColliderOne.GetComponent<PlayerColliderScript>();

        if (colliderScript.inRange && facingRight)
        {
            colliderScript.targetHealth.Damage(SlashDamage);
        }

        if (colliderScript.inRangeRanged && facingRight)
        {
            colliderScript.enemyHealth.Damage(SlashDamage);
        }

        if (colliderScript.inRangeBoss && facingRight)
        {
            colliderScript.BossHealth.Damage(SlashDamage);
        }


        //timer = 0f;

        yield return null;
    }

    IEnumerator PlayerSwordAttackLeft()
    {

        yield return new WaitForSeconds(0.3f);
        colliderScript = ColliderTwo.GetComponent<PlayerColliderScript>();

        if (colliderScript.inRange && !facingRight)
        {
            colliderScript.targetHealth.Damage(SlashDamage);
        }

        if (colliderScript.inRangeRanged && !facingRight)
        {
            colliderScript.enemyHealth.Damage(SlashDamage);
        }

        if (colliderScript.inRangeBoss && !facingRight)
        {
            colliderScript.BossHealth.Damage(SlashDamage);
        }

        //timer = 0f;

        yield return null;
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

    /*private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && targetHealth == null)
        {            
            targetHealth = other.GetComponent<EnemyMeleeScript>();
        }
    }

    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            inRange = false;
            targetHealth = null;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("inRange");
            inRange = true;
        }

        if (other.gameObject.tag == "Enemy" && targetHealth == null)
        {
            targetHealth = other.GetComponent<EnemyMeleeScript>();
        }

    }*/
}