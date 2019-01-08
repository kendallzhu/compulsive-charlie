using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Processing player commands, and dynamically change player graphics
// For now, spacebar is only control
public class PlayerController : MonoBehaviour {
    // control variables
    public float jumpPress = 0;
    public float jumpRelease = 0;

    // gameplay constants
    public const float maxJumpPower = 400f; // range can go higher with higher energy, this is the minimum cap
    public const float minJumpPower = 80f;
    public const float forwardJumpForce = 100f;
    public const float fallingMinForwardSpeed = .5f; // idea: maybe can make this a profile upgrade?

    public Transform groundCheck1;
    public Transform groundCheck2;
    public bool grounded = false;
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
        // check for grounded
        grounded = Physics2D.Linecast(transform.position, groundCheck1.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheck2.position, 1 << LayerMask.NameToLayer("Ground"));

        // weird jump mechanic just for fun to see movement
        if (Input.GetButtonDown("Jump") || !grounded)
        {

            jumpPress = Time.time;
            /* // on jumps add a random interval so it's not predictable
            if (Input.GetButtonDown("Jump") && grounded)
            {
                jumpPress = Time.time - Random.Range(0f, JumpPeriod(runManager.runState));
            }*/
        }
        if (Input.GetButtonUp("Jump") || !grounded)
        {
            jumpRelease = Time.time;
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

    public float GetJumpPower(float releaseTime)
    {
        RunState runState = runManager.runState;
        float period = JumpPeriod(runState);
        float timing = (releaseTime - jumpPress) % period;
        float power = MaxJumpPower(runState) * timing / period;
        // incorporate jump bonus from current thought
        if (runState.CurrentThought())
        {
            power = runState.CurrentThought().JumpBonus(power);
        }
        return power + minJumpPower;
    }

    void FixedUpdate()
    {
        if (jumpRelease > jumpPress)
        {
            float jumpForce = GetJumpPower(jumpRelease);
            rb2d.AddForce(new Vector2(forwardJumpForce, jumpForce));
            jumpPress = 0;
            jumpRelease = 0;
        }
    }

    // functions for gameplay parameters that depend on runState (emotions, etc.)
    private float PlatformMinForwardSpeed(RunState runState)
    {
        // make fast if lots of negative emotion
        // TODO: add more nuance/ better design
        int e = runManager.runState.emotions.GetTotal();
        if (e < -10)
        {
            return 1f;
        }
        if (e > 10)
        {
            return .4f;
        }
        return .7f;
    }

    private float JumpPeriod(RunState runState)
    {
        // make more crazy/fast if lots of negative emotion (so harder to time)
        // TODO: add more nuance/ better design
        int e = runManager.runState.emotions.GetTotal();
        if (e < -10)
        {
            return .3f;
        }
        if (e > 10)
        {
            return .9f;
        }
        return .6f;
    }

    private float MaxJumpPower(RunState runState)
    {
        // if we are not on the jump pad yet, keep it simple and allow only small jump
        if (!runState.CurrentActivityPlatform() || !runState.CurrentActivityPlatform().jumpPadExplored)
        {
            return minJumpPower;
        }
        // jump power goes up with energy - TODO: tune, at one point I thought decrease w/ score but nah        
        return maxJumpPower * Mathf.Pow(runState.energy/10f, .5f);
    }
}
