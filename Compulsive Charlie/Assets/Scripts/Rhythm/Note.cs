using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    Clock clock;
    NoteManager noteManager;
    NoteHitManager noteHitManager;

    public int id;          // used for SpriteRenderer sorting order
    public int noteType;    // this must correspond to a drum type

    float travelTime = 2f;  // take one second to get to hit area 
    float noteSpeed;
    float travelDistance;
    float timing;    

    void Start()
    {
        clock = FindObjectOfType<Clock>();
        noteManager = FindObjectOfType<NoteManager>();
        noteHitManager = FindObjectOfType<NoteHitManager>();
        
        timing = clock.getTime() + travelTime;
        travelDistance = transform.position.x + Mathf.Abs(GameObject.FindWithTag("HitArea").transform.position.x);
        noteSpeed = travelDistance / travelTime;

        gameObject.GetComponent<SpriteRenderer>().sortingOrder = id; // sort each sprite by when it was created

        noteManager.notes.Add(gameObject);
        noteManager.timings.Add(timing);
    }

    void Update()
    {
        Move();
        CheckMiss();
    }

    void Move()
    {
        transform.Translate(Vector3.left * noteSpeed * Time.deltaTime);
    }

    void CheckMiss()
    {
        if(clock.getTime() - noteManager.window > timing)
        {
            noteHitManager.Miss();
        }
    }
}
