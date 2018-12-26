using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for graphic display of timesteps left - right now just text but hopefully will be nicer
public class JumpDisplay : MonoBehaviour
{
    public PlayerController playerController;
    public float maxBarHeight = 2;

    // Initialization
    void Start()
    {
        // get reference to playerController
        playerController = Object.FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            float power = playerController.GetJumpPower(Time.time);
            float height = maxBarHeight * power / playerController.maxJumpForce;
            transform.localScale = new Vector3(.2f, height, 1f);
        } else
        {
            transform.localScale = new Vector3(.2f, 0, 1f);
        }
    }
}
