using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class PromiseToImprove : Upgrade
{
    void Awake()
    {
        name = "Promise to Improve";
        descriptionText = "Simply Increase Anxiety";
        category = "thought";
        singleUse = false;
    }

    // comb through lists of activities and thoughts and modify them to make upgrade
    public override void Activate(Profile profile)
    {
        profile.initialEmotions.anxiety += 12;
    }

    // criteria for upgrade to be available after a run
    public override bool IsAvailable(Profile profile)
    {
        // default when nothing else is available
        return profile.upgrades.Count(u=> u.singleUse && u.IsAvailable(profile)) < 3;
    }
}