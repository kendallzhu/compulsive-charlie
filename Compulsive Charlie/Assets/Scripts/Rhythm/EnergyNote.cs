using UnityEngine;
using System.Collections;

public class EnergyNote : Note
{
    // custom functions for miss/hit effects
    public override void OnMiss(RunState runState)
    {
        Destroy(gameObject);
    }

    public override void OnHit(RunState runState)
    {
        runState.IncreaseEnergy(1);
        Destroy(gameObject);
    }
}
