using UnityEngine;
using System.Collections;

public class EmotionNote : Note
{
    // custom functions for miss/hit effects
    public override void OnMiss(RunState runState)
    {
        Destroy(gameObject);
    }

    public override void OnHit(RunState runState)
    {
        Debug.Log(type);
        runState.emotions.Equilibrate(type);
        Destroy(gameObject);
    }
}
