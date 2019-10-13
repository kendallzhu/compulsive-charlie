using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChewingFood : Upgrade
{
    void Awake()
    {
        name = "Chewing Food";
        descriptionText = "Makes Eating More Fun";
        category = "action";
    }

    // comb through lists of activities and thoughts and modify them to make upgrade
    public override void Activate(Profile profile)
    {
        foreach (Activity a in profile.activities)
        {
            if (a == Object.FindObjectOfType<BalancedMeal>() || a == Object.FindObjectOfType<Binge>())
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