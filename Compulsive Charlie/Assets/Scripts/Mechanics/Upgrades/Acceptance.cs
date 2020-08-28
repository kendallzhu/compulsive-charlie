using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Acceptance : Upgrade
{
    void Awake()
    {
        name = "Acceptance";
        descriptionText = "It is what it is";
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
        return profile.upgrades.Count(u=> u.name != this.name && u.IsAvailable(profile)) == 0;
    }
}