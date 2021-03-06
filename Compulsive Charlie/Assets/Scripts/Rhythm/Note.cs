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

    public bool isResolved = false;
    public bool isInvisibleHit = false;
    float spawnTime;
    float volume;
    public float arrivalTime;
    Vector2 startingOffset;
    public EmotionType emotionType;
    // "animator" prefabs
    public GameObject hitPrefab;
    public GameObject missPrefab;
    public GameObject deflectPrefab;
    public SpriteRenderer icon;
    public SpriteRenderer arrow;
    public SpriteRenderer xMark;

    void Awake()
    {
        runManager = FindObjectOfType<RunManager>();
        rhythmManager = FindObjectOfType<RhythmManager>();
        hitArea = GameObject.FindWithTag("HitArea").transform;
        icon = transform.Find("Icon").GetComponent<SpriteRenderer>();
        arrow = transform.Find("Arrow").GetComponent<SpriteRenderer>();
        xMark = transform.Find("XMark").GetComponent<SpriteRenderer>();
    }

    public void Initialize(float trueSpawnTime, AudioClip soundClip, float volume = 1)
    {
        this.volume = volume;
        spawnTime = trueSpawnTime;
        arrivalTime = trueSpawnTime + RhythmManager.travelTime;
        startingOffset = transform.position - hitArea.position;
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = soundClip;
        arrow.enabled = false;
        xMark.enabled = false;
        xMark.color = new Color(.24f, .24f, .24f);
    }

    public bool IsSuppressed()
    {
        return runManager.IsSuppressed(emotionType);
    }

    // hack to generate unique float for each note in a group, so their colors don't blend weirdly when they overlap
    private float GetZPosition(EmotionType type)
    {
        float offset = startingOffset.y * .0001f;
        if (type == EmotionType.frustration)
        {
            return 0.01f + offset;
        } else if (type == EmotionType.anxiety)
        {
            return 0.01f + offset;
        } else if (type == EmotionType.despair)
        {
            return 0.02f + offset;
        }
        Debug.Assert(type == EmotionType.None);
        return 0.03f + offset;
    }

    void Update()
    {
        // move note to proper position
        float scaleFactor = (arrivalTime - rhythmManager.time) / RhythmManager.travelTime;
        scaleFactor = Math.Max(0, scaleFactor);
        Vector3 newPos = (Vector2)hitArea.position + startingOffset * scaleFactor;
        // use z position for ordering to make overlap colors more normal
        transform.position = new Vector3(newPos.x, newPos.y, GetZPosition(emotionType));
        // gray out suppressed emotions, add X
        if (IsSuppressed())
        {
            // xMark.enabled = true;

            // hide notes gradually 
            float alpha = Mathf.Max(0, scaleFactor - .5f);
            // float alpha = scaleFactor;
            xMark.color = new Color(xMark.color.r, xMark.color.g, xMark.color.b, alpha);
            arrow.color = new Color(arrow.color.r, arrow.color.g, arrow.color.b, alpha);
            icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, alpha);
            Color c = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, alpha);
        }
    }

    public void OnDeflect()
    {
        // Debug.Assert(!isResolved, "on deflect already resolved");
        if (!isResolved) // only destroy if note is not taken care of by another process
            Destroy(gameObject);
        isResolved = true;
        GameObject deflect = Instantiate(deflectPrefab, transform.position, Quaternion.identity, transform.parent);
        deflect.GetComponent<MoveFadeOut>().SetDirection(new Vector2(-startingOffset.x, startingOffset.y));
    }

    // functions for miss/hit effects
    public void OnMiss(RunState runState)
    {
        Debug.Assert(!isResolved, "on miss already resolved");
        isResolved = true;
        runState.BreakCombo();
        MissEffect(runState);
        Instantiate(missPrefab, transform.position, Quaternion.identity, hitArea);
        rhythmManager.player.GetComponent<Animator>().SetTrigger("activityFail");
        runState.CurrentActivityPlatform().unSuppressedEmotions.Remove(emotionType);
        Destroy(gameObject);
    }

    public void OnSuppress(RunState runState)
    {
        // AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        // audioSource.clip = Resources.Load<AudioClip>("drum_kit/Crash_Cymbal");
        
        // you can hit them invisibly!
        if (this.isInvisibleHit)
        {
            StartCoroutine(HitAfterDelay(0, runState));
            runState.CurrentActivityPlatform().unSuppressedEmotions.Add(emotionType);
        } else
        {
            // if not hit, fail silently
            runState.IncreaseEnergy(-1);
            runState.emotions.Add(emotionType, 1);
            Instantiate(missPrefab, transform.position, Quaternion.identity, hitArea);
            runState.BreakCombo();
        }
    }

    public void OnHit(float time, RunState runState)
    {
        StartCoroutine(HitAfterDelay(0, runState));
    }

    // (Delay so that sound occurs when note would have arrived)
    public IEnumerator HitAfterDelay(float delay, RunState runState)
    {
        // Debug.Assert(!isResolved, "hit after delay - already resolved");
        isResolved = true;
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(delay);
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = this.volume;
        runState.IncreaseCombo();
        if (!IsSuppressed())
        {
            HitEffect(runState);
        }
        // show graphic effect
        Instantiate(hitPrefab, transform.position, Quaternion.identity, hitArea);
        rhythmManager.player.GetComponent<Animator>().ResetTrigger("activityFail");
        // play audio and destroy when done
        audioSource.Play();
        Destroy(gameObject, audioSource.clip.length);
    }

    public IEnumerator AutoHitAfterDelay(float delay)
    {
        Debug.Assert(!isResolved, "auto hit after delay - already resolved");
        isResolved = true;
        emotionType = EmotionType.None;
        // dark out note and move it back
        transform.localScale = new Vector3(.5f, .5f, 0);
        transform.Translate(new Vector3(0, 0, -1f));
        yield return new WaitForSeconds(delay);
        transform.localScale = new Vector3(0f, 0f, 0);
        // Instantiate(hitPrefab, transform.position, Quaternion.identity, hitArea);
        // play audio and destroy when done
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
        Destroy(gameObject, audioSource.clip.length);
    }

    public void OnAutoHit(float time)
    {
        // seperate AutoHitAfterDelay function with less effects?
        StartCoroutine(AutoHitAfterDelay(arrivalTime - time));
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
