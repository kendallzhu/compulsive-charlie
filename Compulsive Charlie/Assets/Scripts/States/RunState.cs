using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

// Class for storing all data relevant to a given run
public class RunState {
    public int timeSteps;
    public bool done;
    public int energy;
    public int energyCap;
    public int jumpPower;
    public int rhythmCombo;
    public EmotionState emotions;
    public List<ActivityPlatform> activityHistory;
    public List<Thought> thoughtHistory;
    // records schedule activity completion (and more nuance?)
    public int schedulePoints = 0;
    // height could have more meaning?
    public int height = 0;

    // the next set of prospective platforms
    public List<ActivityPlatform> spawnedPlatforms = new List<ActivityPlatform>();

    // basic constructor
    public RunState(int initialEnergy, int energyCap, EmotionState initialEmotions)
    {
        this.timeSteps = 0;
        this.energy = initialEnergy;
        this.energyCap = energyCap;
        this.emotions = initialEmotions;
        this.rhythmCombo = 0;
        this.activityHistory = new List<ActivityPlatform>();
        this.thoughtHistory = new List<Thought>();
    }

    public void IncreaseEnergy(int amount)
    {
        energy += amount;
        // energy = System.Math.Min(energy, energyCap);
        energy = System.Math.Max(energy, 0);
    }

    public void EquilibrateEnergy(float factor = .4f)
    {
        int diff = 0 - energy;
        energy += (int)(diff * factor) + Math.Sign(diff);
    }

    public ActivityPlatform CurrentActivityPlatform()
    {
        if (activityHistory.Count == 0)
        {
            return null;
        }
        return activityHistory.Last();
    }

    public int GetRaiseAmount()
    {
        return (int)Mathf.Sqrt(energy) - emotions.Extremeness();
    }

    public void IncreaseCombo()
    {
        rhythmCombo++;
        ActivityPlatform ap = CurrentActivityPlatform();
        if (rhythmCombo > ap.bestCombo)
        {
            ap.bestCombo = rhythmCombo;
        }
    }

    public void ResetCombo()
    {
        rhythmCombo = 0;
    }

    public void BreakCombo()
    {
        rhythmCombo = 0;
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

    // return number of timesteps since last occurrence of activity, or run start
    public int TimeSinceLast(Activity activity)
    {
        int time = timeSteps;
        for (int i = 0; i < activityHistory.Count; i++)
        {
            if (activityHistory[i].activity == activity)
            {
                time = activityHistory.Count - i;
            }
        }
        return time;
    }
}
