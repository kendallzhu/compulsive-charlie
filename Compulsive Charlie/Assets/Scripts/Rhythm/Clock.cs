using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {
    float startTime;

	void Start()
    {
        restartClock();
	}

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            restartClock();
        }
	}

    void restartClock()
    {
        startTime = Time.time;
    }

    public float getTime()
    {
        return Time.time - startTime;
    }
}