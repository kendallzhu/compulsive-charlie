using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for storing all data relevant to a given run
public class RunState {
    public int timeSteps;
    public int energy;
    public EmotionState emotions;
    public List<ActivityPlatform> activityHistory;
    public List<Thought> thoughtHistory;
    public List<int> scoreHistory;
    // todo: jump bonus?

    // the next set of prospective platforms
    public List<ActivityPlatform> spawnedPlatforms = new List<ActivityPlatform>();

    // full constructor
    public RunState(int timeSteps, 
                    int energy,
                    EmotionState emotions,
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
    public RunState(int initialEnergy, EmotionState initialEmotions)
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
