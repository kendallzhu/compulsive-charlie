using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LetLoose : Thought
{
    void Awake()
    {
        name = "Let Loose";
        descriptionText = "Forget everything - might lose touch with anxiety and sadness";
        isUnlocked = false;
        energyCost = 1;
        jumpPower = 5;
    }

    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        if (runState.activityHistory.Count == 0)
        {
            return 0;
        }
        if (runState.activityHistory.Last().activity.name == "Drinking")
        {
            return 1;
        }
        return 0;
    }

    // how this thought modifies run state when thunk
    public override void CustomAcceptEffect(RunState runState)
    {
        runState.emotions.Equilibrate(.1f);
    }
}