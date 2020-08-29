using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class JustDoIt : Upgrade
{
    void Awake()
    {
        name = "Vow to 'Just Do It'";
        descriptionText = "Absolutely No Effect";
        category = "thought";
        singleUse = false;
    }

    // comb through lists of activities and thoughts and modify them to make upgrade
    public override void Activate(Profile profile)
    {
        // profile.initialEnergy += 1;
    }

    // criteria for upgrade to be available after a run
    public override bool IsAvailable(Profile profile)
    {
        // default when nothing else is available
        return profile.upgrades.Count(u=> u.singleUse && u.IsAvailable(profile)) < 3;
    }
}