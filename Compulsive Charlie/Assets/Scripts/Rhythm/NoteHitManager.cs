using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHitManager : MonoBehaviour
{
    //public GameObject HitManager;
    GameObject missNote;
    GameObject hitNote;

    NoteManager noteManager;
    GameObject noteStatus;    

    private void Start()
    {
        noteManager = FindObjectOfType<NoteManager>();
        missNote = gameObject.transform.Find("miss").gameObject;
        hitNote = gameObject.transform.Find("hit").gameObject;
    }

    public void checkHit(float timing, int drumType)
    {
        Debug.Log("Timing: " + timing);
        float start = noteManager.timings[0] - noteManager.window;
        float end = noteManager.timings[0] + noteManager.window;

        Debug.Log("Start: " + start + " End: " + end);

        if (timing >= start && timing <= end) {
            // We can use offset to see how "good" a hit was
            // float offset = timing - noteManager.timings[0];

            if (drumType == noteManager.notes[0].GetComponent<Note>().noteType) {
                Hit();
            } else {
                Miss();
            }
        }

        // if a note is not near, then we don't do anything
    }

    public void Miss()
    {
        StartCoroutine(ShowAndHide(missNote, 0.1f));
        noteManager.DestroyNote();
    }

    public void Hit()
    {
        StartCoroutine(ShowAndHide(hitNote, 0.1f));
        noteManager.DestroyNote();
    }

    public IEnumerator ShowAndHide(GameObject go, float delay) {
        go.SetActive(true);
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }
}
