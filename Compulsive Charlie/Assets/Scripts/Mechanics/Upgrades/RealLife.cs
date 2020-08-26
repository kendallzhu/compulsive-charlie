using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class RealLife : Upgrade
{
    void Awake()
    {
        name = "Real Life";
        descriptionText = "???";
        category = "thought";
    }

    // comb through lists of activities and thoughts and modify them to make upgrade
    public override void Activate(Profile profile)
    {
        SceneManager.LoadScene("Start");
    }

    // criteria for upgrade to be available after a run
    public override bool IsAvailable(Profile profile)
    {
        return profile.upgrades.Count() == 1;
    }
}