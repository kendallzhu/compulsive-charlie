using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ActivityEnergyCapUpgrade : Upgrade
{
    public virtual bool isRelevantActivity(Activity a)
    {
        return true;
    }

    public virtual void CustomActivate(Profile profile)
    {
        return;
    }

    // comb through lists of activities and thoughts and modify them to make upgrade
    public override void Activate(Profile profile)
    {
        foreach (Activity a in profile.activities)
        {
            if (isRelevantActivity(a))
            {
                a.IncreaseEnergyCap();
            }
        }
        CustomActivate(profile);
        return;
    }

    // criteria for upgrade to be available after a run
    public override bool IsAvailable(Profile profile)
    {
        RunState lastRun = profile.allRuns.Last();
        List<ActivityPlatform> relevantActivities = lastRun.activityHistory.Where(ap => isRelevantActivity(ap.activity)).ToList();
        if (relevantActivities.Count == 0)
        {
            return false;
        }
        foreach (ActivityPlatform ap in relevantActivities)
        {
            if (ap.bestCombo >= ap.activity.song.mediumCombo)
            {
                return true;
            }
        }
        return false;
    }
}
