using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InnerFire : Upgrade
{
    void Awake()
    {
        name = "Inner Fire";
        descriptionText = "Generate energy through the day";
        category = "thought";
    }

    // comb through lists of activities and thoughts and modify them to make upgrade
    public override void Activate(Profile profile)
    {
        profile.energyRegen = 2;
    }

    // criteria for upgrade to be available after a run
    public override bool IsAvailable(Profile profile)
    {
        RunState lastRunState = profile.allRuns.Last();
        return lastRunState.activityHistory.Count() <= 12;
    }
}