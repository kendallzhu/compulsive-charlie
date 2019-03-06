using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpFresh : Upgrade
{
    void Awake()
    {
        name = "Wake Up Fresh";
        descriptionText = "gr8 morning";
    }

    // comb through lists of activities and thoughts and modify them to make upgrade
    public override void Activate(Profile profile)
    {
        profile.initialEmotions = new EmotionState(0, 0, 0);
        profile.initialEnergy = 20;
    }

    // criteria to unlock this upgrade during a run
    public override bool IsUnlock(RunState runState, Profile profile)
    {
        return true;
    }
}