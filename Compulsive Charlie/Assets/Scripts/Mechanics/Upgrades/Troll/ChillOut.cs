using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class ChillOut : Upgrade
{
    void Awake()
    {
        name = "Chill Out";
        descriptionText = "No more work- aholism pls";
        category = "thought";
        singleUse = false;
    }

    // comb through lists of activities and thoughts and modify them to make upgrade
    public override void Activate(Profile profile)
    {
        Activity study = Object.FindObjectOfType<Study>();
        Activity chores = Object.FindObjectOfType<Chores>();
        study.suppressedEmotions.Clear();
        chores.suppressedEmotions.Clear();
    }

    // criteria for upgrade to be available after a run
    public override bool IsAvailable(Profile profile)
    {
        Activity study = Object.FindObjectOfType<Study>();
        // default when nothing else is available
        return study.suppressedEmotions.Count > 0;
    }
}