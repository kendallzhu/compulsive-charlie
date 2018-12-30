using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for handling the interactions with the main physical ground of the platform
public class PlatformGround : MonoBehaviour {
    private ActivityPlatform ap;

    void Awake()
    {
        GameObject platform = this.transform.parent.gameObject;
        ap = platform.GetComponent<ActivityPlatform>();
    }

    // detect when player lands
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if Charlie arrives on this platform we trigger updates
        if (other.name == "Charlie" && !ap.explored)
        {
            ap.explored = true;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ap.runManager.AdvanceTimeStep(ap);
        }
    }
}
