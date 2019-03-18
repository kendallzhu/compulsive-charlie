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

    public RunManager runManager;
    public GameObject Note; // note prefab

    public float time;
    private List<float> noteSpawnTimes = new List<float>();
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
        activity.rhythmPattern.ForEach(i => noteSpawnTimes.Add(i * tempoIncrement));
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
        // user spawn notes for testing
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SpawnNote(time);
        }
        // spawn the next preloaded note if the time has come
        if (noteSpawnTimes.Count > 0 && time >= noteSpawnTimes[0])
        {
            // spawn note, with time adjusted to be exact with intended pattern
            SpawnNote(noteSpawnTimes[0]);
            noteSpawnTimes.RemoveAt(0);
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
                }
                else
                {
                    // stun? miss that note?
                }
            }
        }
    }

    // create a note with specified spawn time
    void SpawnNote(float spawnTime)
    {
        Vector3 staffPos = transform.parent.position;
        Vector3 startingPos = new Vector3(staffPos.x + travelDist, staffPos.y);
        GameObject note = Instantiate(Note, startingPos, Quaternion.identity, transform.parent);
        note.GetComponent<Note>().Initialize(spawnTime);
        notes.Add(note.GetComponent<Note>());
    }
}
