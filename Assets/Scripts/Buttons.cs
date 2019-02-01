using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private Pause pause;
    public GameObject plyr;
    public Button btn;

  
    void Awake()
    {
        btn.onClick.AddListener(OnClick);
        pause = plyr.GetComponent<Pause>();
    }

    private void OnClick()
    {
        pause.SetPaused = false;
        Time.timeScale = 1;
        Debug.Log("resume");
    }

    public void quit()
    {

        SceneManager.LoadScene("Title");

    }

}