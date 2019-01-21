﻿using UnityEngine;

[RequireComponent(typeof(Raycasts), typeof(PlayerInput), typeof(PlayerInfo))]
public class Movement : MonoBehaviour {

    private PlayerInput handler;
    private PlayerInfo playerInfo;
    private Rigidbody2D rb2d;
    private Raycasts groundCheck;
    private Facing facing = Facing.Neutral;
    private bool canWallJump = false;


    // isjumping
    private bool isJumping = false;
    public bool Jumping { get { return isJumping; } }

    //variables
    private readonly float fallMultiplier = 6.7f, 
                           lowJumpMultiplier = 5f, 
                           jumpForce = 12.3f, 
                           velocityMinimum = 10;

    private void Awake()
    {
        handler = GetComponent<PlayerInput>();
        playerInfo = GetComponent<PlayerInfo>();
        rb2d = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<Raycasts>();
    }

    private void Update()
    {
        if (handler.Xaxis > -0.1f && handler.Xaxis < 0.1f)
        {
            //Debug.Log(rb2d.velocity.x + " before");
            facing = Facing.Neutral;
            //rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            //Debug.Log(rb2d.velocity.x + " after");
        }
        ExecuteWallJump();
        DoJump();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        DoFall();
    }

    private void MovePlayer()
    {
        if (handler.Xaxis < 0)
        {
            facing = Facing.Left;
            rb2d.velocity = new Vector2(-playerInfo.Speed, rb2d.velocity.y);
        }
        if (handler.Xaxis > 0)
        {
            facing = Facing.Right;
            rb2d.velocity = new Vector2(playerInfo.Speed, rb2d.velocity.y);
        }
    }

    private void DoJump()
    {
        //check if input goes down while grounded
        if (groundCheck.Grounded && handler.GetJumpButtonDown())
        {
            // play sound here
            isJumping = true;
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }

        //check if input is released (up) or if no input
        if (handler.GetJumpButtonUp() || !handler.GetJumpButton())
        {
            isJumping = false;
        }
    }

    private void DoFall()
    {
        if (!groundCheck.Grounded)
        {
            // this changes the gravity to make the player jump low
            if (rb2d.velocity.y < velocityMinimum)
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb2d.velocity.y > velocityMinimum && !handler.GetJumpButton())
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            canWallJump = true;
        }
    }

    private void ExecuteWallJump()
    {
        if (canWallJump)
        {
            canWallJump = false;
            if (facing == Facing.Left && !groundCheck.Grounded && handler.GetJumpButtonDown())
            {
                Debug.Log("wall is hit");
                //rb2d.AddForce(new Vector2(jumpForce / 2, jumpForce / 2), ForceMode2D.Impulse);
                rb2d.AddForce(new Vector2(50, 50), ForceMode2D.Impulse);
                return;
            }
            else if (facing == Facing.Right && !groundCheck.Grounded && handler.GetJumpButtonDown())
            {
                rb2d.AddForce(new Vector2(-jumpForce / 2, jumpForce / 2), ForceMode2D.Impulse);
                return;
            }

        }
    }
}
