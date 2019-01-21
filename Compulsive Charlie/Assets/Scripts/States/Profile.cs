using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class for storing overall persistent game state/progress
public class Profile
{
    // these lists are initially populated by GameManager
    // (through stuff we put as gameObjects in the editor)
    public List<Thought> thoughts;
    public List<Activity> activities;
    public List<Upgrade> upgrades;
    public EmotionState emotionEquilibriums;
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
        emotionEquilibriums = new EmotionState(0, 0, 0);
        initialMoney = 50;
        initialEnergy = 0;
        thoughts = new List<Thought>();
        activities = new List<Activity>();
        upgrades = new List<Upgrade>();
        experience = 0;
        energyCap = 20;
        energyRegen = 3;
        allRuns = new List<RunState>();
    }
}

