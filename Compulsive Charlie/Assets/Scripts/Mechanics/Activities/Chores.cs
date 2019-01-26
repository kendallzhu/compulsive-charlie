using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chores : Activity
{
    void Awake()
    {
        name = "Chores";
        descriptionText = "life ops";
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        return 1;
    }

    // height of associated platform if it comes after given run state
    public override int HeightRating(RunState runState)
    {
        return 4;
    }

    // how this activity modifies run state when rhythm is hit
    public override void HitEffect(RunState runState)
    {
        runState.emotions.AddAnxiety(-2);
    }

    // how this activity modifies run state when rhythm is missed
    public override void MissEffect(RunState runState)
    {
        runState.emotions.AddFrustration(3);
    }
}
