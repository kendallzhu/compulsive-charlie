using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent class for thought mechanic in game
public abstract class Thought : MonoBehaviour
{
    // consts
    private const float colorBase = 0.05f;

    // unique name
    new public string name;
    public string descriptionText;
    public string infoText; // for full info?

    // changeable parameters
    public bool isUnlocked = false;
    public int energyCost = 0; // now its just a requirement
    public int minJumpPower = 0;
    public int maxJumpPower = 0;
    // which emotion(s) it hides
    public EmotionType emotionType = EmotionType.None;

    // derives color from the invisible emotions list
    public Color GetColor()
    {
        if (emotionType == EmotionType.None)
        {
            return new Color(1, 1, 1);
        }
        float r = colorBase, g = colorBase, b = colorBase;
        if (emotionType == EmotionType.anxiety)
        {
            g = 1;
        }
        if (emotionType == EmotionType.frustration)
        {
            r = 1;
        }
        if (emotionType == EmotionType.despair)
        {
            b = 1;
        }
        return new Color(r, g, b, 1f);
    }

    // non-emotion thought-specific availability conditions 
    // (Don't use activity history - to keep modular)?
    public abstract int CustomAvailability(RunState runState);

    // whether this thought is available, given state of run
    public int Availability(RunState runState)
    {
        // check if thought is unlocked and there is enough energy to use it
        if (!isUnlocked || runState.energy < energyCost)
        {
            return 0;
        }
        return CustomAvailability(runState);
    }

    // how this thought modifies given state of run when activated
    public virtual void CustomAcceptEffect(RunState runState)
    {
        return;
    }

    // common accept effect
    public void AcceptEffect(RunState runState)
    {
        int chosenJumpPower = GameObject.FindObjectOfType<JumpArrow>().GetJumpPower();
        runState.jumpPower = chosenJumpPower;
        runState.IncreaseEnergy(-energyCost);
        // make thought-specific effects
        CustomAcceptEffect(runState);
    }

    // how this thought modifies given state of run when rejected
    public virtual void CustomRejectEffect(RunState runState)
    {
        // default nothing
        return;
    }

    // common reject effect
    public void RejectEffect(RunState runState)
    {
        // if we reject a thought with no energy and nowhere left to go, explode emotions
        if (runState.energy == 0)
        {
            const int explosion = 5;
            runState.emotions.Add(EmotionType.anxiety, explosion);
            runState.emotions.Add(EmotionType.frustration, explosion);
            runState.emotions.Add(EmotionType.despair, explosion);
        }
        // drain energy
        runState.IncreaseEnergy(-1);
        // make thought-specific effects
        CustomRejectEffect(runState);
    }

    // how this thought modifies jump power when active
    // (default: no impact)
    public virtual float JumpBonus(float power)
    {
        return power;
    }

    // how this thought modifies probability of last activity being available again
    // (default: no impact)
    public virtual float Repeat(float probOffered)
    {
        return probOffered;
    }
}
