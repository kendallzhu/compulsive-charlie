using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNothing : Activity
{
    void Awake()
    {
        name = "Do Nothing";
        descriptionText = "wait - actually nothing?";
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
        return defaultPlatformHeightDiff;
    }

    // how this activity modifies run state when rhythm is hit
    public override void HitEffect(RunState runState)
    {
        runState.emotions.Equilibrate(.1f);
    }

    // how this activity modifies run state when rhythm is missed
    public override void MissEffect(RunState runState)
    {
        return;
    }
}
