using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Class for storing all data relevant to a given run
public class RunState {
    public int timeSteps;
    public bool done;
    public int energy;
    public int energyCap;
    public int money;
    public int jumpPower;
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
    public RunState(int initialMoney, int initialEnergy, int energyCap, EmotionState initialEmotions)
    {
        this.timeSteps = 0;
        this.money = initialMoney;
        this.craving = 0;
        this.cravingMultiplier = 1;
        this.energy = initialEnergy;
        this.energyCap = energyCap;
        this.emotions = initialEmotions;
        this.activityHistory = new List<ActivityPlatform>();
        this.thoughtHistory = new List<Thought>();
        this.moneyHistory = new List<int>();
    }

    public void IncreaseCraving(int amount)
    {
        craving += cravingMultiplier * amount;
        if (craving < 0)
        {
            craving = 0;
        }
    }

    public void IncreaseEnergy(int amount)
    {
        energy += amount;
        energy = System.Math.Min(energy, energyCap);
        energy = System.Math.Max(energy, 0);
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

    public int MoneyDiff(int time = 0)
    {
        if (moneyHistory.Count < time + 1)
        {
            return 0;
        }
        return money - moneyHistory[moneyHistory.Count - time - 1];
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

    // return number of timesteps since last occurrence of activity, or run start
    public int TimeSinceLast(Activity activity)
    {
        int time = timeSteps;
        for (int i = 0; i < activityHistory.Count; i++)
        {
            if (activityHistory[i].activity == activity)
            {
                time = activityHistory.Count - i - 1;
            }
        }
        return time;
    }
}
