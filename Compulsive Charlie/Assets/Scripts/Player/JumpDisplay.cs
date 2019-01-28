using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for graphic display of timesteps left - right now weird bar but hopefully will be nicer
public class JumpDisplay : MonoBehaviour
{
    private RunManager runManager;
    public float maxBarHeight;

    // Initialization
    void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
        // bar will actually go larger than this due to energy increasing jump cap
        maxBarHeight = 1f;
    }

    void Update()
    {
        // should be * max willpower/energy TODO: change display
        float maxPower = 15;
        float power = runManager.runState.jumpPower;
        float height = maxBarHeight * power / maxPower;
        transform.localScale = new Vector3(.2f, height, 1f);
    }
}
