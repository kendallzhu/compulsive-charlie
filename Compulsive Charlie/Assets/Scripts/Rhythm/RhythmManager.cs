using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// class for spawning stuff
public class NoteSpawnSpec
{
    public float spawnTime;
    public EmotionType type;
    public AudioClip clip;
    public int angle;

    public NoteSpawnSpec(float spawnTime, EmotionType type, AudioClip clip, int angle)
    {
        this.spawnTime = spawnTime;
        this.type = type;
        this.clip = clip;
        this.angle = angle;
    }
}

public class RhythmManager : MonoBehaviour
{
    // how forgiving we are for note hits
    public const float hitWindowLate = .07f;
    public const float hitWindowEarly = .07f;
    // how far to the right of the hit area are notes spawned
    public const float travelDist = 16f;
    // how long it takes for notes to get to hit area
    public const float travelTime = 1.5f;
    // time between smallest increments of a rhythm pattern
    public const float tempoIncrement = .19f;
    // duration before arrival time that is considered a miss for the incoming note
    // (if you hit earlier than this, then it won't be punished)
    public const float earlyHitPeriod = tempoIncrement;
    // duration after arrival time that is considered a miss for the next note
    public const float lateHitPeriod = hitWindowLate + tempoIncrement / 2;
    // how to scale light beam width based on energy
    public const float beamWidthFactor = .5f;
    // beam constants and how fast to level up/down when around them
    public const float minBeamWidth = 1f;
    // pull angleOffset towards current energy level, rate per second proportional to difference
    public const float angleChangeRate = .2f;
    // Notes spawned below this angle get auto hit - this is so as player moves up lowest notes don't clutter gameplay
    // Hopefully there will be more notes overall in the higher levels, though, so it's worth it.
    public const int autoHitAngle = -10;

    public PlayerController player;
    public GameObject hitArea;
    public GameObject NoteLight;
    public float beamWidth;
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
    private List<NoteSpawnSpec> notesToSpawn = new List<NoteSpawnSpec>();
    private List<Note> notes = new List<Note>(); // active notes (in order)
    private float angleOffset; // used for going up and down levels

    void Awake()
    {
        // get reference to managers + player
        runManager = Object.FindObjectOfType<RunManager>();
        gameManager = Object.FindObjectOfType<GameManager>();
        tutorialManager = Object.FindObjectOfType<TutorialManager>();
        player = Object.FindObjectOfType<PlayerController>();
        beamWidth = minBeamWidth;
        angleOffset = 0;
    }

    public void StartRhythm(Activity activity_)
    {
        lateHitPeriodEnd = 0;
        angleOffset = 0;
        activity = activity_;
        runManager.runState.ResetCombo();
        LoadSong();
    }

    public void StopRhythm()
    {
        notes.ForEach(note => Destroy(note));
        notes.Clear();
        activity = null;
    }

    private void LoadSong()
    {
        // reset time
        time = 0;
        // load in notes for this activity, sort by timing
        List<NoteSpec> pattern = activity.song.notes.OrderBy(n => n.timing).ToList();
        if (runManager.runState.timeSteps == 0)
        {
            // dummy song for first
            pattern = new List<NoteSpec>
            {
                new NoteSpec(0, "C", 0),
                new NoteSpec(3, "C", 0),
            };
        }
        NoteSpec easiestNote = activity.song.notes.OrderBy(n => n.angle).OrderBy(n => n.timing).ToList()[0];
        for (int i = 0; i < pattern.Count; i++)
        {
            NoteSpec n = pattern[i];
            float spawnTime = n.timing * tempoIncrement;
            AudioClip clip = Resources.Load<AudioClip>(n.instrument + "/" + n.pitch);
            // choose a note type based on current emotional state
            EmotionState curr = runManager.runState.emotions;
            EmotionType type = n.type;
            // if specified, do that, else choose either energy, or an emotion (w/ weighted probability)
            if (n != easiestNote && n.type == EmotionType.None)
            {
                // double chance for the dominant emotion
                if (Random.Range(0, 60) < curr.GetMaxValue())
                {
                    type = curr.GetDominantEmotion();
                }
                // else just proportional to emotion value / 60
                else if (Random.Range(0, 60) < curr.anxiety)
                {
                    type = EmotionType.anxiety;
                }
                else if (Random.Range(0, 60) < curr.anxiety)
                {
                    type = EmotionType.anxiety;
                }
                else if (Random.Range(0, 60) < curr.anxiety)
                {
                    type = EmotionType.anxiety;
                }
            }
            // also first activity is all energy notes if need to show tutorial
            if (runManager.runState.activityHistory.Count() < 2 && 
                gameManager.showTutorial && !tutorialManager.shownEmotionNoteTutorial)
            {
                type = EmotionType.None;
            }
            notesToSpawn.Add(new NoteSpawnSpec(spawnTime, type, clip, n.angle));
        }
    }

    bool IsInsideBeam(Note note)
    {
        float middleY = player.transform.position.y;
        float distanceFromCenter = Mathf.Abs(note.transform.position.y - middleY);
        bool outsideBeam = distanceFromCenter > (beamWidth + .01f) / 2;
        return !outsideBeam;
    }

    bool IsTouchingBeam(Note note)
    {
        float middleY = player.transform.position.y;
        float distanceFromCenter = Mathf.Abs(note.transform.position.y - middleY);
        const float noteRadius = .5f;
        return distanceFromCenter - beamWidth / 2 <= noteRadius;
    }

    void Update()
    {
        RunState runState = runManager.runState;
        // do nothing if there is a tutorial
        if (tutorialManager.canvas.activeSelf)
        {
            return;
        }

        // adjust light beam width based on current energy
        float newBeamWidth = runState.energy * beamWidthFactor;
        newBeamWidth = Mathf.Max(newBeamWidth, minBeamWidth);
        if (activity != null)
        {
            // apply activity-specific energy cap
            newBeamWidth = Mathf.Min(newBeamWidth, activity.energyCap / 2f);
        }
        beamWidth = Mathf.Lerp(beamWidth, newBeamWidth, .01f);
        Light light = NoteLight.GetComponent<Light>();
        light.cookieSize = beamWidth + .015f; // this is to avoid small slivers of black initially

        // adjust angle offset to build up/down if the player is doing very well or poor
        // (pull towards current energy level, at rate proportional to delta)
        float targetAngle = runState.energy;
        if (activity)
        {
            targetAngle = Mathf.Min(runState.energy, activity.energyCap);
        }
        float changeRate = (targetAngle - angleOffset) * angleChangeRate * Time.deltaTime;
        angleOffset += changeRate;

        // destroy all notes falling outside of the beam
        foreach (Note note in new List<Note>(notes))
        {
            if (!IsInsideBeam(note) && IsTouchingBeam(note))
            {
                note.OnDeflect();
                notes.Remove(note);
            }
            // only show arrows for notes inside the beam (active ones)
            GameObject arrow = note.transform.Find("Arrow").gameObject;
            if (arrow)
            {
                arrow.SetActive(IsInsideBeam(note));
            } else
            {
                Debug.Log("Expected note to have arrow child gameobject!");
            }
        }

        // update time - with current settings goes in increments of about .016
        time += Time.deltaTime;
        // spawn the next preloaded note if the time has come
        if (notesToSpawn.Count > 0 && time >= notesToSpawn[0].spawnTime)
        {
            // spawn note, with time adjusted to be exact with intended pattern
            SpawnNote(notesToSpawn[0]);
            notesToSpawn.RemoveAt(0);
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
        if (inputAnimPreb && Time.timeScale == 1)
        {
            Instantiate(inputAnimPreb, hitArea.transform.position, Quaternion.identity, hitArea.transform);
        }
        if (notes.Count > 0)
        {
            // detect rhythm hits/misses on the nearest note
            float epsilon = .01f;
            // handle all notes that are coming at the same time
            List<Note> nearestNotes = notes.Where((n) => n.arrivalTime - notes[0].arrivalTime < epsilon).ToList();
            // rhythm miss - too late
            if (time > nearestNotes[0].arrivalTime + hitWindowLate)
            {
                foreach (Note n in nearestNotes)
                {
                    notes.Remove(n);
                    n.OnMiss(runManager.runState);
                }
                // update late hit period so late hits do not affect future notes
                lateHitPeriodEnd = time + lateHitPeriod;
            }
            // otherwise, possible hit
            else if (up || left || down || right)
            {
                List<EmotionType> hitTypes = new List<EmotionType>();
                if (up) { hitTypes.Add(EmotionType.None); }
                if (down) { hitTypes.Add(EmotionType.anxiety); }
                if (left) { hitTypes.Add(EmotionType.despair); }
                if (right) { hitTypes.Add(EmotionType.frustration); }
                if (time > nearestNotes[0].arrivalTime - hitWindowEarly)
                {
                    foreach (Note n in nearestNotes)
                    {
                        // hit as long as the needed key was pressed
                        if (hitTypes.Contains(n.type))
                        {
                            notes.Remove(n);
                            n.OnHit(time, runManager.runState);
                        }
                    }
                }
                else if (time > lateHitPeriodEnd && (time > nearestNotes[0].arrivalTime - earlyHitPeriod))
                {
                    // meaningful false hits cause miss next note
                    foreach (Note n in nearestNotes)
                    {
                        notes.Remove(n);
                        n.OnMiss(runManager.runState);
                    }
                }
            }
        }
        // no notes left - then spawn more to repeat the pattern
        // NOW WHOLE SONGS
        /* else if (activity != null && notesToSpawn.Count == 0)
        {
            LoadSong();
            // abort if the player is almost at the end of the platform
            // (so no notes can spawn that reach player after they reach end)
            float lastSpawnTime = notesToSpawn.Last().spawnTime;
            ActivityPlatform ap = runState.CurrentActivityPlatform();
            float distLeft = ap.x + ap.length - player.transform.position.x;
            if ((lastSpawnTime + travelTime - time) * player.PlatformMinForwardSpeed(runState) > distLeft)
            {
                notesToSpawn.Clear();
                notesToSpawn.Clear();
            }
        } */
        // activate appropriate tutorials
        // show rhythm tutorial once some notes appear on screen
        bool noteVisible = notes.Count > 0 && notes[0].transform.position.x < hitArea.transform.position.x + 5;
        if (gameManager.showTutorial && !tutorialManager.shownRhythmTutorial && noteVisible)
        {
            tutorialManager.ActivateRhythmTutorial();
        }

        // show emotion note tutorial once some emotion note seen
        bool emotionNoteVisible = notes.Count > 0 && notes[0].type != EmotionType.None && IsInsideBeam(notes[0]);
        // bool emotionNoteArrived = emotionNoteVisible && (time > notes[0].arrivalTime - hitWindowEarly);
        if (gameManager.showTutorial && !tutorialManager.shownEmotionNoteTutorial && emotionNoteVisible)
        {
            tutorialManager.ActivateEmotionNoteTutorial();
        }
    }

    // create a note with specified type + spawn time
    void SpawnNote(NoteSpawnSpec n)
    {
        float spawnAngle = n.angle - angleOffset;
        Vector3 offset = Quaternion.Euler(0, 0, spawnAngle) * new Vector3(travelDist, 0, 0);
        Vector3 destPos = hitArea.transform.position;
        Vector3 startingPos = destPos + offset;
        GameObject note;
        if (n.type == EmotionType.None)
        {
            note = Instantiate(energyNote, startingPos, Quaternion.identity, transform.parent);
        }
        else if (n.type == EmotionType.anxiety)
        {
            note = Instantiate(anxietyNote, startingPos, Quaternion.identity, transform.parent);
        }
        else if (n.type == EmotionType.frustration)
        {
            note = Instantiate(frustrationNote, startingPos, Quaternion.identity, transform.parent);
        }
        else if (n.type == EmotionType.despair)
        {
            note = Instantiate(despairNote, startingPos, Quaternion.identity, transform.parent);
        }
        else
        {
            Debug.Log("invalid note type");
            return;
        }
        note.GetComponent<Note>().Initialize(n.spawnTime, n.clip);

        // notes coming from far enough below get auto-hit!
        if (spawnAngle < autoHitAngle)
        {
            note.GetComponent<Note>().OnAutoHit(time);
        } else
        {
            notes.Add(note.GetComponent<Note>());
        }
    }
}
