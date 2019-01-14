using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private InputHandler jumpButt;
    //jumpbutton define

    private bool isJumping = false;
    public bool Jumping { get { return isJumping; } }
    // isjumping

    [SerializeField]
    private float jumpForce,
    fallSpeed = 0.1f,
        jumpTime = 1f,
        initialMultiplier = 3f;
    private Vector2 vectorDown;
    //variables
    private float jumpTimeCounter;
    //handling variables

    private Rigidbody2D rb;

  //  [SerializeField]
  //  private AudioSource audioSource;

  // [SerializeField]
   // private AudioClip jumpSound;

    private GroundedCheck groundCheck;
    // classes


	private void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        vectorDown = new Vector2(rb.velocity.x, -1);
        jumpButt = new InputHandler();
       // audioSource = GetComponent<AudioSource>();
        groundCheck = GetComponent<GroundedCheck>();
	}
	//awake
   
	private void FixedUpdate ()
    {
        DoJump();
        DoFall();
	}
    //update

    private void ZeroVel()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
    }
    //just a shortcut to make velocity zero
   
    private void DoJump()
    {
        //check if input goes down while grounded
        if (groundCheck.Grounded && jumpButt.GetJumpButtonDown())
        {
           //audioSource.PlayOneShot(jumpSound);
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = -vectorDown * (jumpForce * initialMultiplier);
        }
        //check if input is held while jumping
        if (jumpButt.GetJumpButton() && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = -vectorDown * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        //check if input is released (up)
        if (jumpButt.GetJumpButtonUp())
        {
            isJumping = false;
        }
    }
    // DoJump

    private void DoFall()
    {
        if (!groundCheck.Grounded && !isJumping)
        {
            // the reason why i dont like using vector2.down is because it is (0,1) and that stops verticle movement
            rb.velocity += vectorDown * (fallSpeed * Time.deltaTime);
        }
    }
     //Dofall
}
//Jump