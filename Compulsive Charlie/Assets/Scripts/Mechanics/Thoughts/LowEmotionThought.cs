using UnityEngine;
using System.Collections;

public class LowEmotionThought : Thought
{
    // whether this activity is available, given state of run
    public override int CustomAvailability(RunState runState)
    {
        int value = runState.emotions.GetMaxValue();
        if (runState.emotions.GetDominantEmotion() == emotionType && value >= 5 && value <= 15)
        {
            return 1;
        }
        return 0;
    }
}
