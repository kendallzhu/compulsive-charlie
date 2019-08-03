using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleCollectable : MonoBehaviour
{
    public Vector2 fadeDestination;

    private RunManager runManager;

    void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
    }

    // detect when player collects
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Charlie")
        {
            runManager.runState.scoreMultiplier += 1;
            gameObject.AddComponent<MoveFadeOut>();
            gameObject.GetComponent<MoveFadeOut>().SetMovement(new Vector2(0, 2f));
        }
    }
}
