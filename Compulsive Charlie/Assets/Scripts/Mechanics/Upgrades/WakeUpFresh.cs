using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WakeUpFresh : Upgrade
{
    void Awake()
    {
        name = "Wake Up Fresh";
        descriptionText = "Went to bed on time! Start tomorrow with more energy.";
        category = "action";
    }

    // comb through lists of activities and thoughts and modify them to make upgrade
    public override void Activate(Profile profile)
    {
        profile.initialEnergy = profile.energyCap;
    }

    // criteria for upgrade to be available after a run
    public override bool IsAvailable (Profile profile)
    {
        RunState lastRunState = profile.allRuns.Last();
        return lastRunState.activityHistory.Count() <= 12;
    }
}