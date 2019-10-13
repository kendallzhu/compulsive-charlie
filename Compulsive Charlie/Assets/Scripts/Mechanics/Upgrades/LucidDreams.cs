using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LucidDreams : Upgrade
{
    void Awake()
    {
        name = "Lucid Dreams";
        descriptionText = "Makes Sleeping More Fun";
        category = "action";
    }

    // comb through lists of activities and thoughts and modify them to make upgrade
    public override void Activate(Profile profile)
    {
        foreach (Activity a in profile.activities)
        {
            if (a == Object.FindObjectOfType<SleepIn>() || a == Object.FindObjectOfType<GoToBed>())
            {
                a.IncreaseEnergyCap();
            }
        }
        return;
    }

    // criteria for upgrade to be available after a run
    public override bool IsAvailable(Profile profile)
    {
        return true;
    }
}