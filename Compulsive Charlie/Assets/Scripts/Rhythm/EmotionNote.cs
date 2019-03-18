using UnityEngine;
using System.Collections;

public class EmotionNote : Note
{
    public string type;
    // custom functions for miss/hit effects
    public override void OnMiss(RunState runState)
    {
        Destroy(gameObject);
    }

    public override void OnHit(RunState runState)
    {
        runState.emotions.Equilibrate(type);
        Destroy(gameObject);
    }
}
