using UnityEngine;
using System.Collections;

public class EmotionNote : Note
{
    // custom functions for miss/hit effects
    public override void MissEffect(RunState runState)
    {
        // increase more if lower
        runState.emotions.Equilibrate(emotionType, .2f, 20);
        runState.emotions.Add(emotionType, 1);
    }

    public override void HitEffect(RunState runState)
    {
        // Debug.Log(emotionType);
        runState.emotions.Equilibrate(emotionType);
    }
}
