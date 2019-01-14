using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private InputHandler handler;
    private PlayerInfo playerInfo;

    private readonly float speedMultiplier = 2.5f;

    private void Awake()
    {
        handler = new InputHandler();
        playerInfo = GetComponent<PlayerInfo>();        
    }

    

    private void Update()
    {
        
        if (handler.Xaxis < 0)
        {
            transform.Translate(-playerInfo.Speed * speedMultiplier * Time.deltaTime, 0, 0);
        }
        if (handler.Xaxis > 0)
        {
            transform.Translate(playerInfo.Speed * speedMultiplier * Time.deltaTime, 0, 0);
        }
        
    }
    
}
