using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;

    void Update()
    {
        Vector3 setPosition = transform.position;

        if (player.transform.position.x < 2.7f)
            setPosition.x = -1.6f;
        if (player.transform.position.x > 2.7f && player.transform.position.x < 12.3f)
            setPosition.x = 7.43f;
        if (player.transform.position.x > 12.3f && player.transform.position.x < 21f) //+ 9.6
            setPosition.x = 16.46f; //+9,03
        if (player.transform.position.x > 21f && player.transform.position.x < 30f)
            setPosition.x = 25.49f;
        if (player.transform.position.x > 30f && player.transform.position.x < 39f)
            setPosition.x = 34.52f;
        if (player.transform.position.x > 39f && player.transform.position.x < 48f)
            setPosition.x = 43.55f;

        transform.position = setPosition;
    }
 
}
