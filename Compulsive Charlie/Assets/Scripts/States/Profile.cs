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
    public EmotionState emotionEquilibriums;
    public List<Activity> schedule;
    public int initialMoney;
    public int initialEnergy;
    public int energyRegen;
    public int energyCap;
    // exp buys upgrades
    public int experience;
    public List<RunState> allRuns;

    // constructor - (I think this will only be called once on game start)
    public Profile()
    {
        // set starting profile of the game - TODO: Tune according to story of game, maybe start out shittier
        emotionEquilibriums = new EmotionState(10, 10, 10);
        initialMoney = 50;
        initialEnergy = 2;
        thoughts = new List<Thought>();
        activities = new List<Activity>();
        upgrades = new List<Upgrade>();
        schedule = new List<Activity>();
        experience = 0;
        energyCap = 10;
        energyRegen = 1;
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
}

