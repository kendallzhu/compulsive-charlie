using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNothing : Activity
{
    void Awake()
    {
        name = "Do Nothing";
        descriptionText = "wait - actually nothing?";
        heightRating = 0;
        emotionEffect = new EmotionState(0, 0, 0);
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        // only used if all other default activities are not available (see runManager)
        return 0;
    }

    // height of associated platform if it comes after given run state
    public override int HeightRating(RunState runState)
    {
        // special - always be the default when available
        return runState.GetRaiseAmount() + defaultPlatformHeightDiff;
    }
}
