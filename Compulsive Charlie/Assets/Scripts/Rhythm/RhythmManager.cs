using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    // how forgiving we are for note hits
    public const float hitWindowLate = .05f;
    public const float hitWindowEarly = .05f;
    // how far to the right of the hit area are notes spawned
    public const float travelDist = 16f;
    // how long it takes for notes to get to hit area
    public const float travelTime = 1.5f;
    // time between smallest increments of a rhythm pattern
    public const float tempoIncrement = .2f;
    // duration after window that is considered a late hit for that note
    public const float lateHitPeriod = tempoIncrement / 2;
    // duration between repeating measures of same activity
    public const float measureOffset = .4f;

    public PlayerController player;
    public RunManager runManager;
    // note prefabs
    public GameObject energyNote;
    public GameObject anxietyNote;
    public GameObject frustrationNote;
    public GameObject despairNote;

    public float time;
    public float lateHitPeriodEnd;
    private Activity activity;
    private List<float> noteSpawnTimes = new List<float>();
    private List<string> noteSpawnTypes = new List<string>();
    private List<Note> notes = new List<Note>(); // active notes (in order)

    void Awake()
    {
        // get reference to runManager + player
        runManager = Object.FindObjectOfType<RunManager>();
        player = Object.FindObjectOfType<PlayerController>();
    }

    public void StartRhythm(Activity activity_)
    {
        lateHitPeriodEnd = 0;
        activity = activity_;
    }

    public void StopRhythm()
    {
        activity = null;
        // notes.ForEach(n => Destroy(n.gameObject));
        // notes.Clear();
        noteSpawnTimes.Clear();
        noteSpawnTypes.Clear();
        runManager.runState.ResetCombo();
    }

    private void LoadMeasure()
    {
        // Debug.Log("load measure");
        // reset time
        time = -measureOffset;
        // load in notes for this activity
        List<int> pattern = activity.rhythmPattern;
        for (int i = 0; i < pattern.Count; i++)
        {
            noteSpawnTimes.Add(pattern[i] * tempoIncrement);
            // choose a note type based on the activity emotion notes
            EmotionState curr = runManager.runState.emotions;
            /*int a = activity.emotionNotes.anxiety + curr.Extremeness("anxiety");
            int f = activity.emotionNotes.frustration + curr.Extremeness("frustration");
            int d = activity.emotionNotes.despair + curr.Extremeness("despair");*/
            int a = curr.anxiety;
            int f = curr.frustration;
            int d = curr.despair;
            int total = a + f + d + 10;

            string type = "energy";
            int r = Random.Range(0, total);
            if (r < a)
            {
                type = "anxiety";
            }
            else if (r < a + f)
            {
                type = "frustration";
            }
            else if (r < a + f + d)
            {
                type = "despair";
            }
            noteSpawnTypes.Add(type);
        }
    }

    void Update()
    {
        // update time - with current settings goes in increments of about .016
        time += Time.deltaTime;
        // spawn the next preloaded note if the time has come
        if (noteSpawnTimes.Count > 0 && time >= noteSpawnTimes[0])
        {
            Debug.Assert(noteSpawnTimes.Count == noteSpawnTypes.Count);
            // spawn note, with time adjusted to be exact with intended pattern
            SpawnNote(noteSpawnTimes[0], noteSpawnTypes[0]);
            noteSpawnTimes.RemoveAt(0);
            noteSpawnTypes.RemoveAt(0);
        }
        if (notes.Count > 0)
        {
            Note nearestNote = notes[0];
            // rhythm miss
            if (time > nearestNote.arrivalTime + RhythmManager.hitWindowLate)
            {
                nearestNote.OnMiss(runManager.runState);
                notes.Remove(nearestNote);
                // update late hit period so late hits do not affect future notes
                lateHitPeriodEnd = time + lateHitPeriod;
            }
            // detect rhythm hits
            bool b0 = Input.GetButtonDown("MainButton");
            bool b1 = Input.GetButtonDown("Button1");
            bool b2 = Input.GetButtonDown("Button2");
            bool b3 = Input.GetButtonDown("Button3");
            if (b0 || b1 || b2 || b3)
            {
                string type = b0 ? "energy" : b1 ? "anxiety" : b2 ? "frustration" : "despair";
                if (time > nearestNote.arrivalTime - hitWindowEarly)
                {
                    // perfect hit
                    if (nearestNote.type == type)
                    {
                        nearestNote.OnHit(runManager.runState);
                        notes.Remove(nearestNote);
                    }
                    // semi-hit (use main button to hit emotions)
                    else if (b0)
                    {
                        nearestNote.OnSemiHit(runManager.runState);
                        notes.Remove(nearestNote);
                    }
                }
                else if (time > lateHitPeriodEnd)
                {
                    // meaningful false hits cause miss next note
                    nearestNote.OnMiss(runManager.runState);
                    notes.Remove(nearestNote);
                }
            }
        }
        else if (activity != null && noteSpawnTimes.Count == 0)
        {
            // repeat the pattern
            LoadMeasure();
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
