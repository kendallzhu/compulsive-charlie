﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Note : MonoBehaviour
{
    RunManager runManager;
    RhythmManager rhythmManager;
    Transform hitArea;

    float spawnTime;
    public float arrivalTime;
    float travelDistance;
    public string type;
    // "animator" prefabs
    public GameObject hitPrefab;

    void Awake()
    {
        runManager = FindObjectOfType<RunManager>();
        rhythmManager = FindObjectOfType<RhythmManager>();
        hitArea = GameObject.FindWithTag("HitArea").transform;
    }

    public void Initialize(float trueSpawnTime)
    {
        spawnTime = trueSpawnTime;
        arrivalTime = trueSpawnTime + RhythmManager.travelTime;
        travelDistance = transform.position.x - hitArea.position.x;
    }

    void Update()
    {
        // move note to proper position
        float newX = hitArea.position.x + travelDistance * (arrivalTime - rhythmManager.time) / RhythmManager.travelTime;
        newX = System.Math.Max(hitArea.position.x, newX);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        // make invisible - test
        if (runManager.runState.thoughtHistory.Last().invisibleEmotions.Contains(type))
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
    }

    // functions for miss/hit effects
    public void OnSemiHit(RunState runState)
    {
        runState.IncreaseCombo();
        Destroy(gameObject);
        Instantiate(hitPrefab, transform.position, Quaternion.identity, transform.parent);
    }

    public void OnMiss(RunState runState)
    {
        runState.ResetCombo();
        MissEffect(runState);
        Destroy(gameObject);
    }

    public void OnHit(RunState runState)
    {
        runState.IncreaseCombo();
        HitEffect(runState);
        Destroy(gameObject);
        Instantiate(hitPrefab, transform.position, Quaternion.identity, transform.parent);
    }

    public virtual void HitEffect(RunState runState)
    {
        return;
    }

    public virtual void MissEffect(RunState runState)
    {
        return;
    }
}
