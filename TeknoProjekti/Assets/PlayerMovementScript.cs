using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{

    public float speed;
    public GameObject playerRangePos;
    public GameObject playerArrow;
    private float moveVertical;
    private float moveHorizontal;
    GameObject enemy;
    private bool inRange;

    public float timeBetweenAttacks = 0.5f;
    float timer;


    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {

        if (Input.GetButton("Vertical"))
            transform.Translate(0, 1 * moveVertical * speed * Time.deltaTime, 0);
        if (Input.GetButton("Horizontal"))
            transform.Translate(1 * moveHorizontal * speed * Time.deltaTime, 0, 0);

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
            Instantiate(playerArrow, playerRangePos.transform.position, playerRangePos.transform.rotation);
            timer = 0f;
        }

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