using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RhythmManager : MonoBehaviour
{
    // how forgiving we are for note hits
    public const float hitWindowLate = .1f;
    public const float hitWindowEarly = .05f;
    // how far to the right of the hit area are notes spawned
    public const float travelDist = 16f;
    // how long it takes for notes to get to hit area
    public const float travelTime = 1.5f;
    // time between smallest increments of a rhythm pattern
    public const float tempoIncrement = .2f;
    // duration before arrival time that is considered a miss for the incoming note
    // (if you hit earlier than this, then it won't be punished)
    public const float earlyHitPeriod = tempoIncrement;
    // duration after arrival time that is considered a miss for the next note
    public const float lateHitPeriod = hitWindowLate + tempoIncrement / 2;
    // duration between repeating measures of same activity
    public const float measureOffset = .4f;

    public PlayerController player;
    public GameObject hitArea;
    public RunManager runManager;
    public GameManager gameManager;
    public TutorialManager tutorialManager;
    // note prefabs
    public GameObject energyNote;
    public GameObject anxietyNote;
    public GameObject frustrationNote;
    public GameObject despairNote;
    // input animation prefabs
    public GameObject upKey;
    public GameObject rightKey;
    public GameObject downKey;
    public GameObject leftKey;

    public float time;
    public float lateHitPeriodEnd;
    private Activity activity;
    private List<float> noteSpawnTimes = new List<float>();
    private List<EmotionType> noteSpawnTypes = new List<EmotionType>();
    private List<Note> notes = new List<Note>(); // active notes (in order)

    void Awake()
    {
        // get reference to managers + player
        runManager = Object.FindObjectOfType<RunManager>();
        gameManager = Object.FindObjectOfType<GameManager>();
        tutorialManager = Object.FindObjectOfType<TutorialManager>();
        player = Object.FindObjectOfType<PlayerController>();
    }

    public void StartRhythm(Activity activity_)
    {
        lateHitPeriodEnd = 0;
        activity = activity_;
        runManager.runState.ResetCombo();
    }

    public void StopRhythm()
    {
        activity = null;
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
            // choose a note type based on current emotional state
            EmotionState curr = runManager.runState.emotions;
            int a = curr.anxiety;
            int f = curr.frustration;
            int d = curr.despair;
            int total = a + f + d + 10;

            EmotionType type = EmotionType.None;
            int r = Random.Range(0, total);
            if (r < a)
            {
                type = EmotionType.anxiety;
            }
            else if (r < a + f)
            {
                type = EmotionType.frustration;
            }
            else if (r < a + f + d)
            {
                type = EmotionType.despair;
            }
            // first note is always energy
            if (i == 0)
            {
                type = EmotionType.None;
            }
            // also first activity is all energy notes if need to show tutorial
            if (runManager.runState.activityHistory.Count() <= 2 && 
                gameManager.showTutorial && !tutorialManager.shownEmotionNoteTutorial)
            {
                type = EmotionType.None;
            }
            noteSpawnTypes.Add(type);
        }
    }

    void Update()
    {
        // do nothing if there is a tutorial
        if (tutorialManager.canvas.activeSelf)
        {
            return;
        }
        // only show hitarea if there is an ongoing activity
        if (activity != null)
        {
            hitArea.SetActive(true);
        } else
        {
            hitArea.SetActive(false);
            return;
        }
        
        RunState runState = runManager.runState;
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
        // take inputs + trigger input animations
        bool up = Input.GetButtonDown("up");
        bool left = Input.GetButtonDown("left");
        bool down = Input.GetButtonDown("down");
        bool right = Input.GetButtonDown("right");
        GameObject inputAnimPreb =
            up ? upKey :
            down ? downKey :
            right ? rightKey :
            left ? leftKey : null;
        if (inputAnimPreb)
        {
            Instantiate(inputAnimPreb, hitArea.transform.position, Quaternion.identity, hitArea.transform);
        }
        if (notes.Count > 0)
        {
            // detect rhythm hits/misses on the nearest note
            Note nearestNote = notes[0];
            // rhythm miss - too late
            if (time > nearestNote.arrivalTime + hitWindowLate)
            {
                notes.Remove(nearestNote);
                nearestNote.OnMiss(runManager.runState);
                // update late hit period so late hits do not affect future notes
                lateHitPeriodEnd = time + lateHitPeriod;
            }
            // otherwise, possible hit
            else if (up || left || down || right)
            {
                EmotionType hitType = 
                    up ? EmotionType.None : 
                    down ? EmotionType.anxiety : 
                    right ? EmotionType.frustration : 
                    EmotionType.despair;
                if (time > nearestNote.arrivalTime - hitWindowEarly)
                {
                    // perfect hit
                    if (nearestNote.type == hitType)
                    {
                        notes.Remove(nearestNote);
                        nearestNote.OnHit(runManager.runState);
                    }
                    // semi-hit (use main button to hit emotions)
                    else if (hitType == EmotionType.None)
                    {
                        notes.Remove(nearestNote);
                        nearestNote.OnSemiHit(runManager.runState);
                    }
                }
                else if (time > lateHitPeriodEnd && (time > nearestNote.arrivalTime - earlyHitPeriod))
                {
                    // meaningful false hits cause miss next note
                    notes.Remove(nearestNote);
                    nearestNote.OnMiss(runManager.runState);
                }
            }
        }
        // no notes left - then spawn more to repeat the pattern
        else if (activity != null && noteSpawnTimes.Count == 0)
        {
            LoadMeasure();
            // abort if the player is almost at the end of the platform
            // (so no notes can spawn that reach player after they reach end)
            float lastSpawnTime = noteSpawnTimes.Last();
            ActivityPlatform ap = runState.CurrentActivityPlatform();
            float distLeft = ap.x + ap.length - player.transform.position.x;
            if ((lastSpawnTime + travelTime - time) * player.PlatformMinForwardSpeed(runState) > distLeft)
            {
                noteSpawnTimes.Clear();
                noteSpawnTypes.Clear();
            }
        }
        // activate appropriate tutorials
        // show rhythm tutorial once some notes appear on screen
        bool noteVisible = notes.Count > 0 && notes[0].transform.position.x < hitArea.transform.position.x + 5;
        if (gameManager.showTutorial && !tutorialManager.shownRhythmTutorial && noteVisible)
        {
            tutorialManager.ActivateRhythmTutorial();
        }

        // show emotion note tutorial once some emotion notes appear on screen
        bool emotionNoteVisible = notes.Count > 0 && notes[0].type != EmotionType.None;
        if (gameManager.showTutorial && !tutorialManager.shownEmotionNoteTutorial && emotionNoteVisible)
        {
            tutorialManager.ActivateEmotionNoteTutorial();
        }
    }

    // create a note with specified type + spawn time
    void SpawnNote(float spawnTime, EmotionType type)
    {
        Vector3 destPos = hitArea.transform.position;
        Vector3 startingPos = new Vector3(destPos.x + travelDist, destPos.y);
        GameObject note;
        if (type == EmotionType.None)
        {
            note = Instantiate(energyNote, startingPos, Quaternion.identity, transform.parent);
        }
        else if (type == EmotionType.anxiety)
        {
            note = Instantiate(anxietyNote, startingPos, Quaternion.identity, transform.parent);
        }
        else if (type == EmotionType.frustration)
        {
            note = Instantiate(frustrationNote, startingPos, Quaternion.identity, transform.parent);
        }
        else if (type == EmotionType.despair)
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
