using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : Activity
{
    void Awake()
    {
        name = "Walk";
        descriptionText = "go on a walk";
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.energy >= 5 && runState.TimeSinceLast(this) > 0)
        {
            return 1;
        }
        return 0;
    }

    // height of associated platform if it comes after given run state
    public override int HeightRating(RunState runState)
    {
        return 1;
    }

    // how this activity modifies run state when rhythm is hit
    public override void HitEffect(RunState runState)
    {
        runState.emotions.Equilibrate(.1f);
    }

    // how this activity modifies run state when rhythm is missed
    public override void MissEffect(RunState runState)
    {
        runState.IncreaseEnergy(-1);
    }
}
