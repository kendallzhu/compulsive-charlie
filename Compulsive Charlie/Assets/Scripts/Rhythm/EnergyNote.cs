using UnityEngine;
using System.Collections;

public class EnergyNote : Note
{
    // custom functions for miss/hit effects
    public override void MissEffect(RunState runState)
    {
        runState.EquilibrateEnergy();
    }

    public override void HitEffect(RunState runState)
    {
        runState.IncreaseEnergy(2);
    }
}
