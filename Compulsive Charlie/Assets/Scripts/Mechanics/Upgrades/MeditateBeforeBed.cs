using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MeditateBeforeBed : Upgrade
{
    void Awake()
    {
        name = "Meditate Before Bed";
        descriptionText = "Practice letting go of thoughts";
        category = "action";
    }

    // comb through lists of activities and thoughts and modify them to make upgrade
    public override void Activate(Profile profile)
    {
        profile.meditateBeforeBed = true;
    }

    // criteria for upgrade to be available after a run
    public override bool IsAvailable (Profile profile)
    {
        RunState lastRunState = profile.allRuns.Last();
        return lastRunState.activityHistory.Count() <= 12;
    }
}