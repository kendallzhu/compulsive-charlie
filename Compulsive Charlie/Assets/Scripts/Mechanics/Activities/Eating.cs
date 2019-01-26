using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eating : Activity
{
    private const int timeInterval = 5;

    void Awake()
    {
        name = "Eating";
        descriptionText = "it comes naturally";
        isUnlocked = true;
    }

    // (weighted) availability of activity, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.TimeSinceLast(this) >= timeInterval)
        {
            return 1;
        }
        if (runState.emotions.Extremeness() >= 1)
        {
            return 1;
        }
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
        if (runState.TimeSinceLast(this) < timeInterval)
        {
            runState.IncreaseEnergy(-1);
        }
    }
}
