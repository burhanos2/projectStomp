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
    [Tooltip("lowJumpMultiplier should be less than fallMultiplier")]
    [SerializeField]
    [Range(0.0f, 20.0f)]
    protected float fallMultiplier = 3f, lowJumpMultiplier = 2f;

    [SerializeField]
    [Tooltip("make sure jumpForce is higher than velocityMinimum")]
    [Range(0.1f, 20.0f)]
    protected float jumpForce = 10;

    [SerializeField]
    [Range(0.0f, 3.0f)]
    protected float velocityMinimum = 0;

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

        Debug.Log(rb.velocity);
    }

    private void DoJump()
    {
        //check if input goes down while grounded
        if (groundCheck.Grounded && jumpButt.GetJumpButtonDown())
        {
            // play sound here
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
       
        //check if input is released (up) or if no input
        if (jumpButt.GetJumpButtonUp() || !jumpButt.GetJumpButton())
        {
            isJumping = false;
        }
    }

    private void DoFall()
    {
        if (!groundCheck.Grounded)
        {
            // this changes the gravity to make the player jump low
            if (rb.velocity.y < velocityMinimum)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > velocityMinimum && !jumpButt.GetJumpButton())
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        } 
    }
     
}