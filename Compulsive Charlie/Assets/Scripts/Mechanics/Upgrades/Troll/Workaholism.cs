using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Workaholism : Upgrade
{
    void Awake()
    {
        name = "Work- Aholism";
        descriptionText = "Use work to suppress emotions";
        category = "thought";
        singleUse = false;
    }

    // comb through lists of activities and thoughts and modify them to make upgrade
    public override void Activate(Profile profile)
    {
        Activity study = Object.FindObjectOfType<Study>();
        Activity chores = Object.FindObjectOfType<Chores>();
        study.suppressedEmotions.Add(EmotionType.anxiety);
        study.suppressedEmotions.Add(EmotionType.despair);
        study.suppressedEmotions.Add(EmotionType.frustration);
        chores.suppressedEmotions.Add(EmotionType.anxiety);
        chores.suppressedEmotions.Add(EmotionType.despair);
        chores.suppressedEmotions.Add(EmotionType.frustration);
    }

    // criteria for upgrade to be available after a run
    public override bool IsAvailable(Profile profile)
    {
        Activity study = Object.FindObjectOfType<Study>();
        // default when nothing else is available
        return profile.upgrades.Count(u=> u.singleUse && u.IsAvailable(profile)) < 3 &&
            study.suppressedEmotions.Count == 0;
    }
}