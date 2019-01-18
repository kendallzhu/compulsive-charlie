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
        // should be * max willpower/energy
        float maxPower = PlayerController.powerPerEnergy * 15;
        float power = playerController.jumpPower;
        float height = maxBarHeight * power / maxPower;
        transform.localScale = new Vector3(.2f, height, 1f);
    }
}
