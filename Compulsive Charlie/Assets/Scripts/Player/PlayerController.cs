using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Processing player commands, and dynamically change player graphics
// For now, spacebar is only control
public class PlayerController : MonoBehaviour {
    // gameplay constants
    public const float powerPerEnergy = 50f;
    public const float forwardJumpForce = 100f;
    public const float fallingMinForwardSpeed = .5f; // idea: maybe can make this a profile upgrade?

    // control variables
    public float jumpPower = 0f;

    public Transform groundCheck1;
    public Transform groundCheck2;
    public bool grounded = false;
    public bool nearEdge = false;
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
        // pulse hitbox edge radius to prevent sticking
        if (rb2d.GetComponent<BoxCollider2D>().edgeRadius < .05f)
        {
            rb2d.GetComponent<BoxCollider2D>().edgeRadius = .05f;
        } else
        {
            rb2d.GetComponent<BoxCollider2D>().edgeRadius = 0.04f;
        }

        // check for grounded
        grounded = Physics2D.Linecast(transform.position, groundCheck1.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheck2.position, 1 << LayerMask.NameToLayer("Ground"));

        // check for if near end of platform
        Vector2 forwardPosHigh = new Vector2(transform.position.x + 1, transform.position.y);
        Vector2 forwardPosLow = new Vector2(transform.position.x + 1, transform.position.y - 2);
        nearEdge = !Physics2D.Linecast(forwardPosHigh, forwardPosLow, 1 << LayerMask.NameToLayer("Ground"));

        // increase jump by tapping button
        if (Input.GetButtonDown("Jump") && grounded && !nearEdge) // && runManager.runState.energy > 0)
        {
            jumpPower += powerPerEnergy;
            runManager.runState.energy -= 1;
        }

        // apply passive forward speed when grounded
        Vector2 velocity = rb2d.velocity;
        RunState runState = runManager.runState;
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
    }

    void FixedUpdate()
    {
        // auto-activate jump when near edge of platform
        if (grounded && nearEdge && jumpPower > 0 && rb2d.velocity.y <= 0)
        {
            rb2d.AddForce(new Vector2(forwardJumpForce, jumpPower));
            jumpPower = 0;
        }
    }

    // functions for gameplay parameters that depend on runState (emotions, etc.)
    private float PlatformMinForwardSpeed(RunState runState)
    {
        return 2f;
    }
}
