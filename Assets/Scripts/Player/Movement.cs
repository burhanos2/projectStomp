using UnityEngine;

[RequireComponent(typeof(Raycasts), typeof(PlayerInput), typeof(PlayerInfo))]
public class Movement : MonoBehaviour {

    private PlayerInput handler;
    private PlayerInfo playerInfo;
    private Rigidbody2D rb2d;
    private Raycasts groundCheck;

    // isjumping
    private bool isJumping = false;
    public bool Jumping { get { return isJumping; } }

    //variables
    private readonly float speedMultiplier = 100f, 
                           fallMultiplier = 6.7f, 
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
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        DoJump();
        DoFall();
    }

    private void MovePlayer()
    {
        float velocity = playerInfo.Speed * speedMultiplier * Time.fixedDeltaTime;

        if (handler.Xaxis < 0)
        {
            rb2d.velocity = new Vector2(-velocity, rb2d.velocity.y);
        }
        if (handler.Xaxis > 0)
        {
            rb2d.velocity = new Vector2(velocity, rb2d.velocity.y);
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

}
