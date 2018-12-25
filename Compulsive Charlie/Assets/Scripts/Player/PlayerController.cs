using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Processing player commands, and dynamically change player graphics
public class PlayerController : MonoBehaviour {
    // control variables
    // TODO: different controls for different phases of the game? (no for now, only spacebar for jump)
    public float maxJumpForce = 1000f;
    public float jumpPress = 0;
    public float jumpRelease = 0;
    public float minForwardSpeed = 1;

    public Transform groundCheck1;
    public Transform groundCheck2;
    public bool grounded = false;
    // private Animator anim;
    private Rigidbody2D rb2d;

    void Awake()
    {
        // anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
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
        }
        if (Input.GetButtonUp("Jump") || !grounded)
        {
            jumpRelease = Time.time;
        }
        // avoid going up and over platforms
        Vector2 velocity = rb2d.velocity;
        if (velocity.y < -1 || velocity.y == 0 && grounded)
        {
            float capped = Mathf.Min(velocity.x, 5);
            float newX = Mathf.Max(capped, minForwardSpeed);
            rb2d.velocity = new Vector2(newX, velocity.y);
        }
    }

    float GetJumpPower()
    {
        float power = Mathf.Min(jumpRelease - jumpPress, maxJumpForce);
        return 400 * Mathf.Max(power, .2f);
    }

    void FixedUpdate()
    {
        if (jumpRelease > jumpPress)
        {
            float jumpForce = GetJumpPower();
            rb2d.AddForce(new Vector2(100, jumpForce));
            jumpPress = 0;
            jumpRelease = 0;
        }
    }
}
