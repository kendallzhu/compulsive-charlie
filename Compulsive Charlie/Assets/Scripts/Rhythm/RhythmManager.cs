using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    // how forgiving we are for note hits
    public const float hitWindowLate = .05f;
    public const float hitWindowEarly = .05f;

    public RunManager runManager;
    public GameObject Note; // note prefab
    private List<Note> notes = new List<Note>(); // active notes (in order)

    void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
    }

    void Update()
    {
        // user spawn notes for testing
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 staffPos = transform.parent.position;
            Vector3 startingPos = new Vector3(staffPos.x + 16f, staffPos.y);
            GameObject note = Instantiate(Note, startingPos, Quaternion.identity, transform.parent);
            notes.Add(note.GetComponent<Note>());
        }
        if (notes.Count > 0)
        {
            Note nearestNote = notes[0];
            // rhythm miss
            // Debug.Log(Time.time);
            // Debug.Log(nearestNote.arrivalTime);
            if (Time.time > nearestNote.arrivalTime + RhythmManager.hitWindowLate)
            {
                nearestNote.OnMiss(runManager.runState);
                notes.Remove(nearestNote);
            }
            // rhythm hit
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Time.time > nearestNote.arrivalTime - hitWindowEarly)
                {
                    nearestNote.OnHit(runManager.runState);
                    notes.Remove(nearestNote);
                }
                else
                {
                    // stun? miss that note?
                }
            }
        }
    }
}
