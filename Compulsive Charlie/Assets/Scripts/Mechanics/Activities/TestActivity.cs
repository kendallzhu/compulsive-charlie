using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestActivity : Activity
{

    // Use this for initialization
    void Start()
    {
        name = "Test Activity";
        descriptionText = "testing is great";
        isUnlocked = true;
        associatedThoughts = new List<Thought>();
        // todo: emotion thresholds thing
        emotionThresholds = new Dictionary<string, int[]>();
    }

    // whether this activity is available, given state of run
    public override bool IsAvailable(RunState runState)
    {
        return true;
    }

    // height of associated platform if it comes after given run state
    public override int PlatformHeight(RunState runState)
    {
        List<int> heights = runState.scoreHistory;
        if (heights.Count == 0)
        {
            return 5;
        }
        return heights[heights.Count - 1] + 5;
    }

    // how this activity modifies run state when rhythm is hit
    public override void RhythmEffect(RunState runState)
    {
        return;
    }
}
