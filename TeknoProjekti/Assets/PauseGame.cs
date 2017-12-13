using UnityEngine;
using System.Collections;
using System;

public class PauseGame : MonoBehaviour
{
    public Transform canvas;

    public object audioListen { get; private set; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            AudioListener.pause = true;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            AudioListener.pause = false;
        }
    }

}