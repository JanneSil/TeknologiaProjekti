using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{

    public float speed;
    private float moveVertical;
    private float moveHorizontal;


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

    }
}