using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AmassEnergy : Upgrade
{
    void Awake()
    {
        name = "Amass Energy";
        descriptionText = "Increase energy capacity";
        category = "energy";
    }

    // comb through lists of activities and thoughts and modify them to make upgrade
    public override void Activate(Profile profile)
    {
        return;
    }

    // criteria for upgrade to be available after a run
    public override bool IsAvailable(Profile profile)
    {
        RunState lastRunState = profile.allRuns.Last();
        return lastRunState.activityHistory.Count() <= 12;
    }
}