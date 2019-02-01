using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{

    public GameObject PauseUI;

    private bool paused = false;
    public bool SetPaused
    {
        get { return paused; } set { paused = value; }
    }

    void Start()
    {

        PauseUI.SetActive(false);

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown("joystick 1 button 9")))
        {

            paused = !paused;

        }

        if (paused)
        {

            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {

            PauseUI.SetActive(false);
            Time.timeScale = 1;

        }

    }
}

