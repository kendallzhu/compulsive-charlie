using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for graphic display of timesteps left - right now weird bar but hopefully will be nicer
public class JumpDisplay : MonoBehaviour
{
    public PlayerController playerController;
    public float maxBarHeight;

    // Initialization
    void Awake()
    {
        // get reference to playerController
        playerController = Object.FindObjectOfType<PlayerController>();
        // bar will actually go larger than this due to energy increasing jump cap
        maxBarHeight = 1f;
    }

    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            float power = playerController.GetJumpPower(Time.time);
            // use the constant [min] cap for consistency (don't factor in energy)
            float height = maxBarHeight * power / PlayerController.maxJumpPower;
            transform.localScale = new Vector3(.2f, height, 1f);
        } else
        {
            transform.localScale = new Vector3(.2f, 0, 1f);
        }
    }
}
