using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private InputHandler handler;
    private PlayerInfo playerInfo;

    private void Awake()
    {
        handler = new InputHandler();
        playerInfo = new PlayerInfo();
    }

    private readonly float speedMultiplier = 5;

    private void Update()
    {
        float x = handler.Xaxis * playerInfo.Speed * speedMultiplier * Time.deltaTime;
        transform.Translate(x, 0, 0);

        ///////////////////////////////////////////////////////////////////////////////////// de bovenste keuze is raw joystick movement, de onderste keuze is true joystick movement
        /*
        if (handler.xAxis < 0)
        {
            transform.Translate(-speed * speedMultiplier * Time.deltaTime, 0, 0);
        }
        if (handler.xAxis > 0)
        {
            transform.Translate(speed * speedMultiplier * Time.deltaTime, 0, 0);
        }
        */
    }
    
}
