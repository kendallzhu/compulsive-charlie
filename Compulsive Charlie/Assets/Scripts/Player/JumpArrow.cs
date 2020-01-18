using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpArrow : MonoBehaviour
{
    public ThoughtMenu thoughtMenu;
    public RunManager runManager;
    public PlayerController player;
    Vector2 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        runManager = Object.FindObjectOfType<RunManager>();
        thoughtMenu = Object.FindObjectOfType<ThoughtMenu>();
        player = Object.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Thought thought = thoughtMenu.currentThought;
        if (thought == null)
        {
            // freeze when thought is chosen, and still jumping
            if (!player.grounded)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                transform.position = previousPosition;
            } else
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            return;
        }

        
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        float zeroY = runManager.runState.height;
        float minY = zeroY + ActivityPlatform.PowerToYDiff(thought.minJumpPower);
        float maxY = zeroY + ActivityPlatform.PowerToYDiff(thought.maxJumpPower + 1);
        float range = maxY - minY;
        float period = .5f; // number of seconds per cycle
        // move position up and down until thought has been chosen, then freeze
        float offset = range == 0 ? 0 : (Time.time * range / period) % range;
        transform.position = new Vector2(transform.parent.position.x - 0.3f, minY + offset);
        previousPosition = transform.position;
    }

    // convert from arrow position to jump power
    public int GetJumpPower()
    {
        float zeroY = runManager.runState.height;
        float ydiff = (transform.position.y - zeroY);
        return ActivityPlatform.YDiffToPower(ydiff);
    }
}
