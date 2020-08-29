using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// class for storing overall persistent game state/progress
public class Profile
{
    // these lists are initially populated by GameManager
    // (through stuff we put as gameObjects in the editor)
    public List<Thought> thoughts;
    public List<Activity> activities;
    public List<Upgrade> upgrades;

    // parameters
    public EmotionState emotionEquilibriums = new EmotionState(0, 0, 0);
    public EmotionState defaultInitialEmotions = new EmotionState(4, 4, 4);
    public EmotionState initialEmotions;
    public List<Activity> defaultSchedule = new List<Activity> {
        Object.FindObjectOfType<Chores>(),
        Object.FindObjectOfType<Class>(),
        Object.FindObjectOfType<Study>(),
        Object.FindObjectOfType<BalancedMeal>(),
        Object.FindObjectOfType<HangOut>(),
        Object.FindObjectOfType<Exercise>(),
        Object.FindObjectOfType<Shower>(),
        Object.FindObjectOfType<GoToBed>()
    };
    public List<Activity> schedule;
    public const int defaultInitialEnergy = 2;
    public int initialEnergy;
    public const int defaultEnergyRegen = 0;
    public int energyRegen;
    public const int defaultEnergyCap = 20;
    public int energyCap;
    public const int defaultBedTime = 9;
    public int bedTime;

    public bool meditateBeforeBed;
    public bool exerciseMartialArts;
    // run history
    public List<RunState> allRuns;

    // constructor - (I think this will only be called once on game start)
    public Profile()
    {
        thoughts = new List<Thought>();
        activities = new List<Activity>();
        upgrades = new List<Upgrade>();
        schedule = new List<Activity>();
        allRuns = new List<RunState>();
    }

    // get activity scheduled for given timestep
    public Activity GetSchedule(int time)
    {        
        if (time > schedule.Count)
        {
            if (time > bedTime)
            {
                return Object.FindObjectOfType<GoToBed>();
            }
            return Object.FindObjectOfType<GoToBed>();
        }
        return schedule[time - 1];
    }

    // reset profile to defaults
    public void Reset()
    {
        initialEmotions = new EmotionState(defaultInitialEmotions);
        initialEnergy = defaultInitialEnergy;
        energyRegen = defaultEnergyRegen;
        energyCap = defaultEnergyCap;
        schedule = new List<Activity>(defaultSchedule);
        bedTime = defaultBedTime;
        
    }
    
    public int GetInitialEnergy()
    {
        int energy = initialEnergy;
        if (allRuns.Count > 0)
        {
            int sleepLate = allRuns.Last().activityHistory.Count - bedTime;
            sleepLate = Mathf.Max(0, sleepLate);
            return energy + (10 - sleepLate * 5);
        }
        return energy;
    }
}

