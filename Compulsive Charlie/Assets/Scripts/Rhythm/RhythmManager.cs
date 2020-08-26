using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// class for spawning stuff
public class NoteSpawnSpec
{
    public float spawnTime;
    public EmotionType emotionType;
    public AudioClip clip;
    public float volume;
    public int elevation;

    public NoteSpawnSpec(float spawnTime, EmotionType type, AudioClip clip, int elevation, float volume=1)
    {
        this.spawnTime = spawnTime;
        this.emotionType = type;
        this.clip = clip;
        this.elevation = elevation;
        this.volume = volume;
    }
}

public class RhythmManager : MonoBehaviour
{

    // how forgiving we are for note hits
    public const float hitWindowLate = .15f;
    public const float hitWindowEarly = .12f;
    // how far to the right of the hit area are notes spawned
    public const float travelDist = 15f;
    // how long it takes for notes to get to hit area
    public const float travelTime = 2f;
    // time between smallest increments of a rhythm pattern (changes per activity)
    public float tempoIncrement;
    // duration before arrival time that is considered a miss for the incoming note
    // (if you hit earlier than this, then it won't be punished)
    public float earlyHitPeriod;
    // duration after arrival time that is considered a miss for the next note
    public float lateHitPeriod;
    
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
    List<Note> nearestNotes = new List<Note>(); // notes from the active group arriving at the same time

    void Awake()
    {
        // get reference to managers + player
        runManager = Object.FindObjectOfType<RunManager>();
        gameManager = Object.FindObjectOfType<GameManager>();
        tutorialManager = Object.FindObjectOfType<TutorialManager>();
        player = Object.FindObjectOfType<PlayerController>();
        beamWidth = 0;
    }

    public void StartRhythm(Activity activity_)
    {
        lateHitPeriodEnd = 0;
        activity = activity_;
        LoadSong();
    }

    public void StopRhythm()
    {
        ClearAllNotes();
        activity = null;
        runManager.runState.ResetCombo();
    }

    private int EffectiveEnergy()
    {
        RunState runState = runManager.runState;
        int energy = runState.energy;
        energy -= runState.emotions.GetSum() / 5;
        if (activity != null)
        {
            energy = Mathf.Min(runState.energy, activity.energyCap);
        }
        return Mathf.Max(energy, 0);
    }

    // which notes will be spawned in the middle of the beam 
    private float BeamCenterElevation()
    {
        return EffectiveEnergy() * 3f / 4f;
    }

    private float BeamWidth()
    {
        // calculate so it lets in all notes with from elevations energy/2 to energy
        // (when centered at 3/4 energy)
        return Mathf.Max(EffectiveEnergy() / 2.0f, 1);
    }

    private EmotionType ChooseEmotionType()
    {
        // only energy notes for the initial activity (tutorial)
        if (runManager.runState.timeSteps == 0)
        {
            return EmotionType.None;
        }
        // choose a note type based on current emotional state
        EmotionState curr = runManager.runState.emotions;
        // for now, we are spawning all types of notes, but letting the notes themselves be suppressed (have X's)
        int exposedAnxiety = curr.anxiety;
        // activity.suppressedEmotions.Contains(EmotionType.anxiety) ? 0 : curr.anxiety;
        int exposedFrustration = curr.frustration;
        // activity.suppressedEmotions.Contains(EmotionType.frustration) ? 0 : curr.frustration;
        int exposedDespair = curr.despair;
        // activity.suppressedEmotions.Contains(EmotionType.despair) ? 0 : curr.despair;
        EmotionType type = EmotionType.None;
        // if specified, do that, else choose either energy, or an emotion (w/ weighted probability)
        // (ignore supressed emotions)
        // extra chance for the dominant emotion
        if (Random.Range(0, 80) < curr.GetMaxValue())
        {
            EmotionType dominantEmotion = curr.GetDominantEmotion();
            if (!activity.suppressedEmotions.Contains(dominantEmotion))
            {
                type = dominantEmotion;
            }
        }
        // else just proportional to emotion value
        else if (Random.Range(0, 80) < exposedAnxiety)
        {
            type = EmotionType.anxiety;
        }
        else if (Random.Range(0, 80) < exposedFrustration)
        {
            type = EmotionType.frustration;
        }
        else if (Random.Range(0, 80) < exposedDespair)
        {
            type = EmotionType.despair;
        }
        return type;
    }

    private void LoadSong()
    {
        // for testing new songs
        // activity.song = new Heartbeat(EmotionType.anxiety).song;
        // activity.tempoIncrement = .2f;
        // activity.song = Hero.song;
        // activity.tempoIncrement = .16f;
        // activity.song = WakeUpGetOutThere.song;
        // activity.tempoIncrement = .2f;
        // activity.song = Luma.song;
        // activity.tempoIncrement = .2f;
        // activity.song = MumenRider.song;
        // activity.tempoIncrement = .2f;
        
        // time between smallest increments of a rhythm pattern
        tempoIncrement = activity.tempoIncrement;
        // duration before arrival time that is considered a miss for the incoming note
        // (if you hit earlier than this, then it won't be punished)
        earlyHitPeriod = tempoIncrement;
        // duration after arrival time that is considered a miss for the next note
        lateHitPeriod = hitWindowLate + tempoIncrement / 2;
        // clear out old notes, (should be none, but just in case)
        ClearAllNotes();
        // reset time
        time = 0;

        // load in notes for this activity, sort by timing
        List<NoteSpec> pattern = activity.song.notes.OrderBy(n => n.timing).ToList();
        if (runManager.runState.timeSteps == 0)
        {
            // dummy song for first
            pattern = new List<NoteSpec>
            {
                new NoteSpec(0, "C4", (int)BeamCenterElevation()),
                new NoteSpec(4, "C4", (int)BeamCenterElevation()),
            };
        }
        Debug.Assert(activity.song.Length() > 0);
        NoteSpec easiestNote = activity.song.notes.OrderBy(n => n.elevation).OrderBy(n => n.timing).ToList()[0];
        for (int i = 0; i < pattern.Count; i++)
        {
            NoteSpec n = pattern[i];
            float spawnTime = n.timing * tempoIncrement;
            AudioClip clip = Resources.Load<AudioClip>(n.GetAudioFilePath());
            if (clip == null)
            {
                Debug.Log("Could not find clip: " + n.GetAudioFilePath());
            }
            EmotionType type = EmotionType.None;
            if (n != easiestNote && n.emotionType == EmotionType.None)
            {
                type = ChooseEmotionType();
            }
            // also first activity is all energy notes if need to show tutorial
            if (runManager.runState.activityHistory.Count() < 2 && gameManager.showEmotionNoteTutorial)
            {
                type = EmotionType.None;
            }
            notesToSpawn.Add(new NoteSpawnSpec(spawnTime, type, clip, n.elevation, n.GetVolume()));
        }
    }

    // returns whether note is above beam and thus should be excluded
    bool IsAboveBeam(Note note)
    {
        float middleY = hitArea.transform.position.y;
        float distanceAboveCenter = note.transform.position.y - middleY;
        return distanceAboveCenter > (beamWidth + .015f) / 2;
    }

    bool IsTouchingBeam(Note note)
    {
        float middleY = hitArea.transform.position.y;
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
        float targetDisplayBeamWidth = BeamWidth();
        beamWidth = Mathf.Lerp(beamWidth, targetDisplayBeamWidth, .02f);
        if (Mathf.Abs(beamWidth - targetDisplayBeamWidth) < .5f)
        {
            // extra adjustment so it coverges faster
            beamWidth = Mathf.Lerp(beamWidth, targetDisplayBeamWidth, .0f);
        }
        Light light = NoteLight.GetComponent<Light>();
        light.cookieSize = beamWidth + .015f; // this is to avoid small slivers of black initially
        
        // destroy all notes falling above of the beam
        foreach (Note note in new List<Note>(notes))
        {
            if (IsAboveBeam(note) && IsTouchingBeam(note))
            {
                note.OnDeflect();
                notes.Remove(note);
            }
            // only show arrows for active notes inside the beam
            note.arrow.enabled = !IsAboveBeam(note) && !note.isResolved && !note.IsSuppressed();
        }
        // deal with suppressed notes
        foreach (Note n in new List<Note>(notes))
        {
            if (n.IsSuppressed())
            {
                n.isResolved = true;
            }
            if (n.IsSuppressed() && time >= n.arrivalTime)
            {
                notes.Remove(n);
                n.OnSuppress(runState);
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
            if (notesToSpawn.Count == 0)
            {
                runState.CurrentActivityPlatform().isSongDone = true;
            }
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
        // detect rhythm hits/misses on the incoming group of notes
        if (notes.Count() > 0)
        {
            // deal with next wave of notes
            float epsilon = .01f;
            bool isAboutToSpawnNearest = (notesToSpawn.Count() > 0 &&
                Mathf.Abs(notes[0].arrivalTime - (notesToSpawn[0].spawnTime + travelTime)) < epsilon);
            // contains all notes that are coming at the same time (only reset once all those notes have been resolved)
            if ((nearestNotes.Count() == 0 || nearestNotes.All(n => n.isResolved)) && !isAboutToSpawnNearest)
            {
                nearestNotes = notes.Where((n) => Mathf.Abs(n.arrivalTime - notes[0].arrivalTime) < epsilon).ToList();
            }
            // unresolved list has all the notes of the current group that are still active
            List<Note> unResolvedNearestNotes = nearestNotes.Where(n => !n.isResolved).ToList();
            // rhythm miss - too late
            if (nearestNotes.Count() > 0 && time > nearestNotes[0].arrivalTime + hitWindowLate)
            {
                // only trigger one miss of each type, to avoid drastic swings if song
                List<EmotionType> missTypes = new List<EmotionType>();
                foreach (Note n in unResolvedNearestNotes)
                {
                    notes.Remove(n);
                    if (!missTypes.Contains(n.emotionType))
                    {
                        missTypes.Add(n.emotionType);
                        n.OnMiss(runManager.runState);
                        // reactivate tutorials if miss many notes in a row
                        if (runManager.runState.rhythmBreakCount > 7)
                        {
                            tutorialManager.OnMissingALot();
                        }
                    }
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
                    List<EmotionType> noteTypes = nearestNotes.Select(note => note.emotionType).ToList();
                    // if an erroneous key was pressed, miss all these notes
                    if (!hitTypes.All(noteTypes.Contains))
                    {
                        foreach (Note n in unResolvedNearestNotes)
                        {
                            notes.Remove(n);
                            n.OnMiss(runManager.runState);
                        }
                    }
                    else
                    {
                        // hit the notes for which the key is pressed
                        foreach (Note n in unResolvedNearestNotes)
                        {
                            if (hitTypes.Contains(n.emotionType))
                            {
                                notes.Remove(n);
                                n.OnHit(time, runManager.runState);
                            }
                        }
                        // log hits for invisible suppressed notes!
                        foreach (Note n in nearestNotes)
                        {
                            if (runState.CurrentActivity().suppressedEmotions.Contains(n.emotionType) && hitTypes.Contains(n.emotionType))
                            {
                                // be extra strict about hit window
                                if (time > n.arrivalTime - hitWindowEarly / 2 &&
                                    time < n.arrivalTime + hitWindowLate / 2)
                                {
                                    n.isInvisibleHit = true;
                                }
                            }
                        }
                    }
                }
                else if (time > lateHitPeriodEnd && (time > nearestNotes[0].arrivalTime - earlyHitPeriod))
                {
                    // meaningful false hits cause miss next note
                    foreach (Note n in unResolvedNearestNotes)
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
        if (gameManager.showRhythmTutorial && noteVisible)
        {
            tutorialManager.ActivateRhythmTutorial();
        }

        // show emotion note tutorial once some emotion note seen
        bool emotionNoteVisible = notes.Count > 0 && notes[0].emotionType != EmotionType.None && 
            !notes[0].IsSuppressed() && !IsAboveBeam(notes[0]);
        // bool emotionNoteArrived = emotionNoteVisible && (time > notes[0].arrivalTime - hitWindowEarly);
        if (gameManager.showEmotionNoteTutorial && emotionNoteVisible)
        {
            tutorialManager.ActivateEmotionNoteTutorial();
        }
    }

    // create a note with specified type + spawn time
    void SpawnNote(NoteSpawnSpec n)
    {
        float spawnElevation = n.elevation - BeamCenterElevation();
        Vector3 offset = new Vector3(travelDist, spawnElevation, 0);
        Vector3 destPos = hitArea.transform.position;
        Vector3 startingPos = destPos + offset;
        GameObject note;
        // choose emotion type on spawn to make things more responsive
        n.emotionType = ChooseEmotionType();
        if (n.emotionType == EmotionType.None)
        {
            note = Instantiate(energyNote, startingPos, Quaternion.identity, transform.parent);
        }
        else if (n.emotionType == EmotionType.anxiety)
        {
            note = Instantiate(anxietyNote, startingPos, Quaternion.identity, transform.parent);
        }
        else if (n.emotionType == EmotionType.frustration)
        {
            note = Instantiate(frustrationNote, startingPos, Quaternion.identity, transform.parent);
        }
        else if (n.emotionType == EmotionType.despair)
        {
            note = Instantiate(despairNote, startingPos, Quaternion.identity, transform.parent);
        }
        else
        {
            Debug.Log("invalid note type");
            return;
        }
        note.GetComponent<Note>().Initialize(n.spawnTime, n.clip, n.volume);

        // notes coming from far enough below get auto-hit!
        // round so we keep notes alive that are off by fraction (i.e. 0 notes when elevation = 1)
        if (offset.y < -(int)(BeamWidth() / 2 + .5f))
        {
            note.GetComponent<Note>().OnAutoHit(time);
        } else
        {
            notes.Add(note.GetComponent<Note>());
        }
    }

    void ClearAllNotes()
    {
        foreach (Note note in Object.FindObjectsOfType<Note>())
        {
            Destroy(note.gameObject);
        }
        notesToSpawn.Clear();
        notes.Clear();
        nearestNotes.Clear();
    }
}
