using System;
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
    Vector2 startingOffset;
    public EmotionType type;
    // "animator" prefabs
    public GameObject hitPrefab;
    public GameObject missPrefab;

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
        startingOffset = transform.position - hitArea.position;
        Debug.Log(startingOffset);
    }

    void Update()
    {
        // move note to proper position
        float scaleFactor = (arrivalTime - rhythmManager.time) / RhythmManager.travelTime;
        scaleFactor = Math.Max(0, scaleFactor);
        Vector3 newPos = (Vector2)hitArea.position + startingOffset * scaleFactor;
        transform.position = newPos;
        // make invisible - test
        List<Thought> thoughts = runManager.runState.thoughtHistory;
        if (thoughts.Count > 0 && thoughts.Last().invisibleEmotions.Contains(type))
        {
            // transform.localScale = new Vector3(0, 0, 0);
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
        runState.BreakCombo();
        MissEffect(runState);
        Destroy(gameObject);
        Instantiate(missPrefab, transform.position, Quaternion.identity, transform.parent);
        rhythmManager.player.GetComponent<Animator>().SetTrigger("activityFail");
    }

    public void OnHit(RunState runState)
    {
        runState.IncreaseCombo();
        HitEffect(runState);
        Destroy(gameObject);
        Instantiate(hitPrefab, transform.position, Quaternion.identity, transform.parent);
        rhythmManager.player.GetComponent<Animator>().ResetTrigger("activityFail");
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
