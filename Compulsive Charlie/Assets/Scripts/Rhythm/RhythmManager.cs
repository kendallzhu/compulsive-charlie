using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    // how forgiving we are for note hits
    public const float hitWindowLate = .05f;
    public const float hitWindowEarly = .05f;
    // how far to the right of the hit area are notes spawned
    public const float travelDist = 12f;
    // how long it takes for notes to get to hit area
    public const float travelTime = 1.5f;
    // time between smallest increments of a rhythm pattern
    public const float tempoIncrement = .2f;
    // time between repetitions of a rhythm pattern
    public const float measureOffset = 1f;

    public RunManager runManager;
    // note prefabs
    public GameObject energyNote;
    public GameObject anxietyNote;
    public GameObject frustrationNote;
    public GameObject despairNote;

    public float time;
    private List<float> noteSpawnTimes = new List<float>();
    private List<string> noteSpawnTypes = new List<string>();
    private List<Note> notes = new List<Note>(); // active notes (in order)

    void Awake()
    {
        // get reference to runManager
        runManager = Object.FindObjectOfType<RunManager>();
    }

    public void StartRhythm(Activity activity)
    {
        time = 0;
        // load in notes for this activity
        activity.rhythmPattern.ForEach(i => {
            noteSpawnTimes.Add(i * tempoIncrement);
            noteSpawnTypes.Add("energy");
        });
    }

    public void StopRhythm()
    {
        notes.ForEach(n => Destroy(n.gameObject));
        notes.Clear();
        noteSpawnTimes.Clear();
    }

    void Update()
    {
        // update time - with current settings goes in increments of about .016
        // Debug.Log(Time.deltaTime);
        time += Time.deltaTime;
        
        // spawn the next preloaded note if the time has come
        if (noteSpawnTimes.Count > 0 && time >= noteSpawnTimes[0])
        {
            // spawn note, with time adjusted to be exact with intended pattern
            SpawnNote(noteSpawnTimes[0], noteSpawnTypes[0]);
            noteSpawnTimes.RemoveAt(0);
            noteSpawnTypes.RemoveAt(0);
        }
        if (notes.Count > 0)
        {
            Note nearestNote = notes[0];
            // rhythm miss
            // Debug.Log(Time.time);
            // Debug.Log(nearestNote.arrivalTime);
            if (time > nearestNote.arrivalTime + RhythmManager.hitWindowLate)
            {
                nearestNote.OnMiss(runManager.runState);
                notes.Remove(nearestNote);
            }
            // rhythm hit
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (time > nearestNote.arrivalTime - hitWindowEarly)
                {
                    nearestNote.OnHit(runManager.runState);
                    notes.Remove(nearestNote);
                    // hitting notes spawns more notes
                    if (noteSpawnTimes.Count > -1)
                    {
                        float notesOffset = tempoIncrement * (noteSpawnTimes.Count + notes.Count);
                        noteSpawnTimes.Add(nearestNote.arrivalTime + notesOffset + measureOffset);
                        noteSpawnTypes.Add("energy");
                    }
                }
                else
                {
                    // false hits cause miss next note
                    nearestNote.OnMiss(runManager.runState);
                    notes.Remove(nearestNote);
                }
            }
        }
    }

    // create a note with specified type + spawn time
    void SpawnNote(float spawnTime, string type)
    {
        Vector3 staffPos = transform.parent.position;
        Vector3 startingPos = new Vector3(staffPos.x + travelDist, staffPos.y);
        GameObject note;
        if (type == "energy")
        {
            note = Instantiate(energyNote, startingPos, Quaternion.identity, transform.parent);
        }
        else if (type == "anxiety")
        {
            note = Instantiate(anxietyNote, startingPos, Quaternion.identity, transform.parent);
        }
        else if (type == "frustration")
        {
            note = Instantiate(frustrationNote, startingPos, Quaternion.identity, transform.parent);
        }
        else if (type == "despair")
        {
            note = Instantiate(despairNote, startingPos, Quaternion.identity, transform.parent);
        }
        else
        {
            Debug.Log("invalid note type");
            return;
        }
        note.GetComponent<Note>().Initialize(spawnTime);
        notes.Add(note.GetComponent<Note>());
    }
}
