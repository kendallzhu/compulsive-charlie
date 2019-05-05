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
    public EmotionState defaultInitialEmotions;
    public EmotionState initialEmotions;
    public List<Activity> defaultSchedule;
    public List<Activity> schedule;
    public int defaultInitialEnergy;
    public int initialEnergy;
    public int defaultEnergyRegen;
    public int energyRegen;
    public int defaultEnergyCap;
    public int energyCap;
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
            return schedule.Last();
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
    }
}

