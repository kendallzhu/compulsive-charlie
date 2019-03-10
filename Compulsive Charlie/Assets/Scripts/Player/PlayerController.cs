using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Processing player commands, and dynamically change player graphics
// For now, spacebar is only control
public class PlayerController : MonoBehaviour {
    // gameplay constants
    public const float jumpForcePerEnergy = 80f;
    public const float forwardJumpForce = 40f;
    public const float fallingMinForwardSpeed = .5f;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Transform aboveGroundRight;
    public bool grounded;
    public bool nearEdge;
    public bool nearEdgeLastFrame;
    // private Animator anim;
    private Rigidbody2D rb2d;
    private RunManager runManager;

    void Awake()
    {
        // anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RunState runState = runManager.runState;
        // mock rhythm hits and misses
        if (Input.GetButtonDown("Hit"))
        {
            runState.CurrentActivity().HitEffect(runState);
        }
        if (Input.GetButtonDown("Miss"))
        {
            runState.CurrentActivity().MissEffect(runState);
        }

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

        /* increase jump by spending energy (on tap)
        if (Input.GetButtonDown("Jump") && grounded && runState.energy > 0)
        {
            runState.jumpPower += 1;
            runState.IncreaseEnergy(-1);
        } */

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
    }

    // called from runManager.PostThoughtSelect
    public void Jump()
    {
        RunState runState = runManager.runState;
        if (runState.jumpPower > 0)
        {
            float upwardJumpForce = runState.CurrentThought().JumpBonus(runState.jumpPower * jumpForcePerEnergy);
            rb2d.AddForce(new Vector2(forwardJumpForce, upwardJumpForce));
            runState.jumpPower = 0;
        }
    }

    // functions for gameplay parameters that depend on runState (emotions, etc.)
    private float PlatformMinForwardSpeed(RunState runState)
    {
        return 2f;
    }
}
