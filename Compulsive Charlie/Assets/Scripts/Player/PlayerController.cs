using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Processing player physics, and dynamically change player graphics
// For now, spacebar is only control
public class PlayerController : MonoBehaviour {
    // motion constants
    private const float jumpForcePerEnergy = 220f;
    private const float jumpStartForwardVelocity = 1.5f;
    private const float defaultForwardJumpForce = 40f;
    private List<float> forwardJumpForces = new List<float> { 40f, 40f, 35f, 30f, 27f };
    private const float fallingMinForwardSpeed = .5f;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Transform aboveGroundRight;
    public bool grounded;
    public bool nearEdge;
    public bool nearEdgeLastFrame;

    private Animator anim;
    private Rigidbody2D rb2d;
    private RunManager runManager;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RunState runState = runManager.runState;

        // pulse hitbox edge radius to prevent sticking
        if (rb2d.GetComponent<BoxCollider2D>().edgeRadius < .05f)
        {
            rb2d.GetComponent<BoxCollider2D>().edgeRadius = .05f;
        } else
        {
            rb2d.GetComponent<BoxCollider2D>().edgeRadius = 0.04f;
        }

        // check for grounded
        grounded = Physics2D.Linecast(transform.position, groundCheckLeft.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Ground"));

        // apply passive forward speed when grounded
        Vector2 velocity = rb2d.velocity;
        if (grounded)
        {
            float newX = Mathf.Max(velocity.x, PlatformMinForwardSpeed(runState));
            rb2d.velocity = new Vector2(newX, velocity.y);
        }
        // apply falling forward speed when falling
        else if (velocity.y < -1)
        {
            float newX = Mathf.Max(velocity.x, fallingMinForwardSpeed);
            rb2d.velocity = new Vector2(newX, velocity.y);
        }

        // auto-activate jump callback sequence when first near edge of platform
        nearEdgeLastFrame = nearEdge;
        nearEdge = !Physics2D.Linecast(aboveGroundRight.position, groundCheckRight.position, 1 << LayerMask.NameToLayer("Ground"));
        // runManager.PreJump => thoughtMenu.Activate => runManager.PostThoughtSelect => player.Jump
        if (grounded && nearEdge && !nearEdgeLastFrame)
        {
            runManager.PreJump();
        }

        // while jump start animation is playing, stay still
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("charlie_jump_start"))
        {
            rb2d.velocity = new Vector2(0, 0);
        }
        // once jump start animation finished, apply force once
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("charlie_jumping") && runState.jumpPower > 0)
        {
            rb2d.velocity = new Vector2(jumpStartForwardVelocity, rb2d.velocity.y);
            float upwardJumpForce = runState.CurrentThought().JumpBonus(runState.jumpPower * jumpForcePerEnergy);
            float forwardJumpForce = defaultForwardJumpForce;
            if (runState.jumpPower >= 0 && runState.jumpPower <= forwardJumpForces.Count())
            {
                forwardJumpForce = forwardJumpForces[runState.jumpPower];
            }
            rb2d.AddForce(new Vector2(forwardJumpForce, upwardJumpForce));
            runState.jumpPower = 0;
        }
        // if jump force is negative, fall straight down
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("charlie_jumping") && runState.jumpPower < 0)
        {
            if (runState.jumpPower == -1)
            {
                // shift Charlie over the ledge once
                rb2d.position = new Vector2(rb2d.position.x - .7f, rb2d.position.y - 2f);
            }
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            runState.jumpPower = -2;
        }
    }

    // called from runManager.PostThoughtSelect
    public void Jump()
    {
        // trigger jump start animation - actual jump^ in Update(), after start anim completes
        anim.SetTrigger("startJump");
    }

    // functions for gameplay parameters that depend on runState (emotions, etc.)
    public float PlatformMinForwardSpeed(RunState runState)
    {
        Activity activity = runState.CurrentActivity();
        if (runState.timeSteps == 0 || runState.CurrentActivityPlatform().isSongDone)
        {
            return 1.5f;
        }
        // set the forward speed slow enough to allow finishing the song
        float songDuration = ((float)activity.song.Length() * activity.tempoIncrement) + 2;
        return (float)(runState.CurrentActivityPlatform().length - 2) / songDuration;
    }
}
