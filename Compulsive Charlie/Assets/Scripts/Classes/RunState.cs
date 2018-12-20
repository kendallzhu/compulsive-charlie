using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MonoBehaviour {
    public int timeSteps;
    public int energy;
    public Dictionary<string, int> emotions;
    public List<string> activityHistory;
    public List<string> thoughtHistory;
    public List<int> scoreHistory;

    // full constructor
    public RunState(int timeSteps, 
                    int energy,
                    Dictionary<string, int> emotions,
                    List<string> activityHistory,
                    List<string> thoughtHistory,
                    List<int> scoreHistory) {
        this.timeSteps = timeSteps;
        this.energy = energy;
        this.emotions = emotions;
        this.activityHistory = activityHistory;
        this.thoughtHistory = thoughtHistory;
        this.scoreHistory = scoreHistory;
    }

    // basic constructor
    public RunState(int initialEnergy, Dictionary<string, int> initialEmotions)
    {
        this.timeSteps = 0;
        this.energy = initialEnergy;
        this.emotions = initialEmotions;
        this.activityHistory = new List<string>();
        this.thoughtHistory = new List<string>();
        this.scoreHistory = new List<int>();
    }
}
