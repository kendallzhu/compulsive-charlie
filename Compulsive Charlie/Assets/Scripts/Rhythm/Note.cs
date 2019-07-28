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
    public GameObject deflectPrefab;

    void Awake()
    {
        runManager = FindObjectOfType<RunManager>();
        rhythmManager = FindObjectOfType<RhythmManager>();
        hitArea = GameObject.FindWithTag("HitArea").transform;
    }

    public void Initialize(float trueSpawnTime, AudioClip soundClip)
    {
        spawnTime = trueSpawnTime;  
        arrivalTime = trueSpawnTime + RhythmManager.travelTime;
        startingOffset = transform.position - hitArea.position;
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = soundClip;
    }

    void Update()
    {
        // move note to proper position
        float scaleFactor = (arrivalTime - rhythmManager.time) / RhythmManager.travelTime;
        scaleFactor = Math.Max(0, scaleFactor);
        Vector3 newPos = (Vector2)hitArea.position + startingOffset * scaleFactor;
        transform.position = newPos;
    }

    public void OnDeflect()
    {
        Destroy(gameObject);
        GameObject deflect = Instantiate(deflectPrefab, transform.position, Quaternion.identity, transform.parent);
        deflect.GetComponent<NoteFadeOut>().SetDirection(new Vector2(-startingOffset.x, startingOffset.y));
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
        Instantiate(missPrefab, transform.position, Quaternion.identity, hitArea);
        rhythmManager.player.GetComponent<Animator>().SetTrigger("activityFail");
    }

    // (Delay so that sound occurs when note would have arrived)
    public IEnumerator HitAfterDelay(float delay, RunState runState)
    {
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(delay);
        runState.IncreaseCombo();
        HitEffect(runState);
        Instantiate(hitPrefab, transform.position, Quaternion.identity, hitArea);
        rhythmManager.player.GetComponent<Animator>().ResetTrigger("activityFail");
        // play audio and destroy when done
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
        Destroy(gameObject, audioSource.clip.length);
    }

    public void OnHit(float time, RunState runState)
    {
        StartCoroutine(HitAfterDelay(arrivalTime - time, runState));
    }

    public void OnAutoHit(float time, RunState runState)
    {
        // seperate AutoHitAfterDelay function with less effects?
        StartCoroutine(HitAfterDelay(arrivalTime - time, runState));
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
