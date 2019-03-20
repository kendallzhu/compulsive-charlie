using UnityEngine;
using System.Collections;

public class EmotionNote : Note
{
    // custom functions for miss/hit effects
    public override void HitEffect(RunState runState)
    {
        // Debug.Log(type);
        runState.emotions.Equilibrate(type);
    }
}
