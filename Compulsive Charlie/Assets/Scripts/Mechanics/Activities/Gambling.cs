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
        return -2;
    }

    // how this activity modifies run state when rhythm is hit
    public override void HitEffect(RunState runState)
    {
        runState.money -= 2;
        runState.emotions.AddAnxiety(-1);
    }

    // how this activity modifies run state when rhythm is missed
    public override void MissEffect(RunState runState)
    {
        runState.money -= 10;
        runState.emotions.AddDespair(3);
    }
}
