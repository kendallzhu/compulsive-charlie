using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for handling the interactions with the end section of the platform
public class JumpPad : MonoBehaviour
{
    private ActivityPlatform ap;

    void Awake()
    {
        GameObject platform = this.transform.parent.gameObject;
        ap = platform.GetComponent<ActivityPlatform>();
    }

    // detect when player lands
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if Charlie enters the "jump Pad" end section of the activity platform, we trigger updates
        if (other.name == "Charlie" && !ap.jumpPadExplored)
        {
            ap.jumpPadExplored = true;
            // triggering effects at end of activity
            ap.runManager.EnterJumpPad(ap);
        }
    }
}
