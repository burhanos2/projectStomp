using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //jumpbutton define
    private InputHandler jumpButt;

    // isjumping
    private bool isJumping = false;
    public bool Jumping { get { return isJumping; } }

    //variables
    [SerializeField]
    protected float jumpForce = 10,
                fallSpeed = 5.6f,
                   jumpTime = 0.3f,
          initialMultiplier = 2f;

    //handling variables
    private float jumpTimeCounter;

    // classes
    private Rigidbody2D rb;
    private GroundedCheck groundCheck;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpButt = GetComponent<InputHandler>();
        groundCheck = GetComponent<GroundedCheck>();
    }

    private void FixedUpdate()
    {
        DoJump();
        DoFall();
    }

    private void ZeroVel()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
    }
    //just a shortcut to make velocity zero without cancelling horizontal movement

    private void DoJump()
    {
        //check if input goes down while grounded
        if (groundCheck.Grounded && jumpButt.GetJumpButtonDown())
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, (jumpForce * initialMultiplier));
        }
        //check if input is held while jumping
        if (jumpButt.GetJumpButton() && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        //check if input is released (up) or if no input
        if (jumpButt.GetJumpButtonUp() || !jumpButt.GetJumpButton())
        {
            isJumping = false;
        }
    }

    private void DoFall()
    {
        if (!groundCheck.Grounded && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, -fallSpeed);
        }
    }
     
}