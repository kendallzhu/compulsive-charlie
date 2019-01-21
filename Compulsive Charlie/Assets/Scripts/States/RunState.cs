using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Class for storing all data relevant to a given run
public class RunState {
    public int timeSteps;
    public int energy;
    public int money;
    public int craving;
    public int cravingMultiplier;
    public EmotionState emotions;
    public List<ActivityPlatform> activityHistory;
    public List<Thought> thoughtHistory;
    public List<int> moneyHistory;
    // height could have more meaning?
    public int height = 0;

    // the next set of prospective platforms
    public List<ActivityPlatform> spawnedPlatforms = new List<ActivityPlatform>();

    // basic constructor
    public RunState(int initialMoney, int initialEnergy, EmotionState initialEmotions)
    {
        this.timeSteps = 0;
        this.money = initialMoney;
        this.craving = 0;
        this.cravingMultiplier = 1;
        this.energy = initialEnergy;
        this.emotions = initialEmotions;
        this.activityHistory = new List<ActivityPlatform>();
        this.thoughtHistory = new List<Thought>();
        this.moneyHistory = new List<int>();
    }

    public ActivityPlatform CurrentActivityPlatform()
    {
        if (activityHistory.Count == 0)
        {
            return null;
        }
        return activityHistory.Last();
    }

    public Activity CurrentActivity()
    {
        ActivityPlatform ap = CurrentActivityPlatform();
        if (ap == null || ap.activity == null)
        {
            return null;
        }
        return ap.activity;
    }

    public Thought CurrentThought()
    {
        if (thoughtHistory.Count == 0)
        {
            return null;
        }
        return thoughtHistory.Last();
    }

    // destroy all platforms in the prospective set except chosen, clear list
    public void ClearSpawned(ActivityPlatform chosen)
    {
        foreach (ActivityPlatform p in spawnedPlatforms)
        {
            if (p != chosen)
            {
                UnityEngine.Object.Destroy(p.gameObject);
            }
        }
        spawnedPlatforms.Clear();
    }
}
