using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile
{
    // these lists are initially populated by GameManager
    // (through stuff we put as gameObjects in the editor)
    public List<Thought> thoughts;
    public List<Activity> activities;
    public List<Upgrade> upgrades;
    public EmotionState emotionEquilibriums;
    public int initialEnergy;

    public List<int> scores;

    // constructor - (I think this will only be called once on game start)
    public Profile()
    {
        // set starting profile of the game
        emotionEquilibriums = new EmotionState();
        initialEnergy = 0;
        thoughts = new List<Thought>();
        activities = new List<Activity>();
        upgrades = new List<Upgrade>();
    }
}

