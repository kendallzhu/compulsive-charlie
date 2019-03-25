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
    public int energyLevel = 0; // now its just a requirement
    public int jumpPower = 0;
    // which emotion(s) it hides
    public List<string> invisibleEmotions = new List<string>();

    // derives color from the invisible emotions list
    public Color GetColor()
    {
        if (invisibleEmotions.Count == 0)
        {
            return new Color(1, 1, 1);
        }
        float r = colorBase, g = colorBase, b = colorBase;
        if (invisibleEmotions.Contains("anxiety"))
        {
            g = 1;
        }
        if (invisibleEmotions.Contains("frustration"))
        {
            r = 1;
        }
        if (invisibleEmotions.Contains("despair"))
        {
            b = 1;
        }
        return new Color(r, g, b, 1f);
    }
    // version of color to tint background after selecting this thought
    public Color BackgroundColor()
    {
        if (invisibleEmotions.Count == 0)
        {
            return new Color(1, 1, 1);
        }
        Color c = GetColor();
        // for sprite, subtract colors to get desired tint
        return new Color(
            1 - (c.g + c.b) / 5,
            1 - (c.r + c.b) / 5, 
            1 - (c.r + c.g) / 5, 
            1
        );
    }

    // non-emotion thought-specific availability conditions 
    // (Don't use activity history - to keep modular)?
    public abstract int CustomAvailability(RunState runState);

    // whether this thought is available, given state of run
    public int Availability(RunState runState)
    {
        // check if thought is unlocked and there is enough energy to use it
        if (!isUnlocked || runState.energy < energyLevel)
        {
            return 0;
        }
        return CustomAvailability(runState);
    }

    // how this thought modifies given state of run when activated
    public virtual void CustomAcceptEffect(RunState runState)
    {
        // default - adds emotion according to the level
        invisibleEmotions.ForEach((e) => runState.emotions.Add(e, 10 - energyLevel));
    }

    // common accept effect
    public void AcceptEffect(RunState runState)
    {
        // set background tint
        GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("Background");
        foreach (GameObject bg in backgrounds)
        {
            bg.GetComponent<SpriteRenderer>().color = BackgroundColor();
        }
        runState.jumpPower += jumpPower;
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
            runState.emotions.Add("anxiety", explosion);
            runState.emotions.Add("frustration", explosion);
            runState.emotions.Add("despair", explosion);
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
