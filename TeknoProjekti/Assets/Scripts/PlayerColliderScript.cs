using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderScript : MonoBehaviour {

    public EnemyMeleeScript targetHealth;
    public EnemyRangedScript enemyHealth;
    public bool inRange;
    public bool inRangeRanged;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            inRange = false;
            targetHealth = null;
        }

        if (other.gameObject.tag == "Ranged")
        {
            inRangeRanged = false;
            enemyHealth = null;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            inRange = true;
        }

        if (other.gameObject.tag == "Enemy" && targetHealth == null)
        {
            targetHealth = other.GetComponent<EnemyMeleeScript>();
        }

        if (other.gameObject.tag == "Ranged")
        {
            inRangeRanged = true;
        }

        if (other.gameObject.tag == "Ranged" && enemyHealth == null)
        {
            enemyHealth = other.GetComponent<EnemyRangedScript>();
        }
    }
}
