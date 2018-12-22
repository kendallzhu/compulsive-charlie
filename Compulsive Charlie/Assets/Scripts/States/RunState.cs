using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState {
    public int timeSteps;
    public int energy;
    public Dictionary<string, int> emotions;
    public List<ActivityPlatform> activityHistory;
    public List<Thought> thoughtHistory;
    public List<int> scoreHistory;

    // full constructor
    public RunState(int timeSteps, 
                    int energy,
                    Dictionary<string, int> emotions,
                    List<ActivityPlatform> activityHistory,
                    List<Thought> thoughtHistory,
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
        this.activityHistory = new List<ActivityPlatform>();
        this.thoughtHistory = new List<Thought>();
        this.scoreHistory = new List<int>();
    }

    public int CurrentScore()
    {
        if (scoreHistory.Count == 0)
        {
            return 0;
        }
        return scoreHistory[scoreHistory.Count - 1];
    }

    public ActivityPlatform CurrentActivityPlatform()
    {
        if (activityHistory.Count == 0)
        {
            return null;
        }
        return activityHistory[activityHistory.Count - 1];
    }
}
