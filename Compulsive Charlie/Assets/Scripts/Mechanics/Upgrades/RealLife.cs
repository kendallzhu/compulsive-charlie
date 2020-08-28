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
        singleUse = false;
    }

    // comb through lists of activities and thoughts and modify them to make upgrade
    public override void Activate(Profile profile)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Credits");
    }

    // criteria for upgrade to be available after a run
    public override bool IsAvailable(Profile profile)
    {
        // when nothing single use is there anymore
        int numSingleUseLeft = profile.upgrades.Count(u => u.singleUse);
        // Debug.Log(numSingleUseLeft);
        return numSingleUseLeft == 0;
    }
}