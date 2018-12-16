using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float maxJumpForce = 1000f;
    public float jumpPress = 0;
    public float jumpRelease = 0;

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
        if (Input.GetButtonDown("Jump"))
        {
            jumpPress = Time.time;
        }
        if (Input.GetButtonUp("Jump"))
        {
            jumpRelease = Time.time;
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
            // Debug.Log(jumpForce);
            rb2d.AddForce(new Vector2(jumpForce / 2, jumpForce));
            jumpPress = 0;
            jumpRelease = 0;
        }
    }
}
