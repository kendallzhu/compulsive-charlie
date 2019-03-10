// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumManager : MonoBehaviour
{
    Clock clock;
    NoteManager noteManager;
    NoteHitManager noteHitManager;

    GameObject drum1;

    void Start()
    {
        clock = FindObjectOfType<Clock>();
        noteManager = FindObjectOfType<NoteManager>();
        noteHitManager = FindObjectOfType<NoteHitManager>();

        drum1 = gameObject.transform.Find("drum1").gameObject;
    }

    void Update()
    {
        hitDrums();
	}

    void hitDrums() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(noteHitManager.ShowAndHide(drum1, 0.2f));
            // parallelism?
            if (noteManager.timings.Count > 0) {
                noteHitManager.checkHit(clock.getTime(), 1);
            }
        }
    }
}