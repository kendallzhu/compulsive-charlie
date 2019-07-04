using UnityEngine;
using System.Collections;

public class HighEmotionThought : Thought
{
    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.GetMaxValue();
        if (runState.emotions.GetDominantEmotion() == emotionType && value >= 10)
        {
            return 1;
        }
        return 0;
    }
}
