using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambling : Activity
{
    void Awake()
    {
        name = "Gambling";
        descriptionText = "escape through the rush";
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
        return defaultPlatformHeightDiff;
    }

    private int Spend(RunState runState)
    {
        if (runState.TimeSinceLast(this) <= 1)
        {
            return runState.money;
        }
        return 10;
    }

    // how this activity modifies run state when rhythm is hit
    public override void HitEffect(RunState runState)
    {
        runState.money -= Spend(runState) / 5;
    }

    // how this activity modifies run state when rhythm is missed
    public override void MissEffect(RunState runState)
    {
        int spent = Spend(runState);
        if (Random.value > .05)
        {
            runState.emotions.AddDespair(5);
        } else
        {
            runState.money += spent * 5;
            runState.emotions.despair = 0;
            runState.craving = 0;
            runState.cravingMultiplier += 1;
        }
        runState.money -= spent;
    }
}
