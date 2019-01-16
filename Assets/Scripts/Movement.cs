using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private InputHandler handler;
    private PlayerInfo playerInfo;
    private Rigidbody2D rb2d;

    private readonly float speedMultiplier = 100f;

    private void Awake()
    {
        handler = GetComponent<InputHandler>();
        playerInfo = GetComponent<PlayerInfo>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (handler.Xaxis > -0.1f && handler.Xaxis < 0.1f)
        {
            rb2d.velocity *= 0;
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = transform.right * playerInfo.Speed * speedMultiplier * Time.fixedDeltaTime;

        if (handler.Xaxis < 0)
        {
            rb2d.velocity = -velocity;
        }
        if (handler.Xaxis > 0)
        {
            rb2d.velocity = velocity;
        }
        
    }
    
}
