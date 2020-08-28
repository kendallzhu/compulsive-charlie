using System;
using System.Collections;
using UnityEngine;

namespace Utility
{
    public class SmoothExpandCycles : MonoBehaviour
    {
        private RectTransform rectTransform;
        public float initialDelay;
        public float cycleDelay;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            LeanTween.scale(rectTransform, new Vector3(60f, 60f, 60f), 5f).setEase(LeanTweenType.easeInExpo)
                .setDelay(cycleDelay)
                .setLoopClamp()
                .setDelay(initialDelay);
            
        }
    }
}