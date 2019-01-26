using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICantKeepScrewingUp : Thought
{
    void Awake()
    {
        name = "I Can't Keep Screwing Up";
        descriptionText = "I can't let everyone down";
        isUnlocked = true;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.emotions.GetDominantEmotion() == "despair")
        {
            return 1;
        }
        return 0;
    }

    // how this thought modifies run state when thunk
    public override void CustomEffect(RunState runState)
    {
        runState.emotions.AddFrustration(3);
        // eliminate gambling from upcoming activities
        foreach (ActivityPlatform p in runState.spawnedPlatforms)
        {
            if (p.activity is Gambling)
            {
                UnityEngine.Object.Destroy(p.gameObject);
            }
        }
    }
}
