using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

    public Text time;
    public int minutes = 0;
    public double seconds = 0;

	
	void Update () {
        timerUpdate();
	}

    public void timerUpdate()
    {
        if (seconds <= 0)
        {
            seconds = 60;
            minutes--;
            
        }
        

        seconds -= Time.deltaTime;
        time.text = string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
    }
}
