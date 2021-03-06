﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

// Script managing all the state and gameplay of a single run
public class RunManager : MonoBehaviour
{
    public const int minPlatformHeightDiff = 3;

    public GameManager gameManager;
    public RunState runState;
    public PlayerController player;
    public RhythmManager rhythmManager;
    public new CameraController camera;
    public ThoughtMenu thoughtMenu;
    public TutorialManager tutorialManager;

    // prefabs
    public GameObject platformPrefab;
    private static readonly int ChantBeforeBed = Animator.StringToHash("chantBeforeBed");
    private static readonly int StartActivity = Animator.StringToHash("startActivity");
    private static readonly int ActivityFail = Animator.StringToHash("activityFail");
    private static readonly int StartJump = Animator.StringToHash("startJump");
    private static readonly int ExerciseKick = Animator.StringToHash("kickExercise");

    // Initialization
    void Awake()
    {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
        thoughtMenu = Object.FindObjectOfType<ThoughtMenu>();
        tutorialManager = Object.FindObjectOfType<TutorialManager>();
        // if no gameManager, load preload scene first
        if (gameManager == null)
        {
            SceneManager.LoadScene(0);
            return;
        }
        // get reference to playerController and rhythmManager
        player = Object.FindObjectOfType<PlayerController>();
        rhythmManager = Object.FindObjectOfType<RhythmManager>();
        // get initial runState based on profile
        runState = new RunState(
            gameManager.profile.GetInitialEnergy(),
            gameManager.profile.energyCap,
            new EmotionState(gameManager.profile.initialEmotions),
            gameManager.profile.bedTime
        );
        Time.timeScale = 1;
    }

    private void Update()
    {
        // cheatcode to skip to recap
        /*if (Input.GetKey("1") && Input.GetKey("2") && Input.GetKey("3"))
        {
            gameManager.EndRun(runState);
        }
        // cheatcode to move forward
        if (Input.GetKey("g") && Input.GetKey("o"))
        {
            ActivityPlatform ap = runState.CurrentActivityPlatform();
            ap.isSongDone = true;
            float xDiff = ap.x + ap.length - player.transform.position.x - 1;
            player.transform.Translate(new Vector3(xDiff, 0, 0));
        }
        // cheatcode to deactivate tutorials
        if (Input.GetKey("n") && Input.GetKey("o"))
        {
            tutorialManager.Skip();
            gameManager.SkipTutorials();
        }
        // cheatcodes to add combo/energy and change emotion
        if (Input.GetKeyDown("0"))
        {
            runState.IncreaseEnergy(10);
        }
        if (Input.GetKeyDown("9"))
        {
            runState.emotions.Equilibrate();
        }
        if (Input.GetKeyDown("1"))
        {
            runState.emotions.Add(EmotionType.anxiety, 3);
        }
        if (Input.GetKeyDown("2"))
        {
            runState.emotions.Add(EmotionType.frustration, 3);
        }
        if (Input.GetKeyDown("3"))
        {
            runState.emotions.Add(EmotionType.despair, 3);
        }
        // cheatcode to upgrade activity (hard mode)
        if (Input.GetKey("u") && Input.GetKey("p"))
        {
            runState.CurrentActivity().energyCap = 20;
        }*/
    }

    // for when the player arrives on next activity, called via trigger in ActivityPlatform
    public void AdvanceTimeStep(ActivityPlatform newActivityPlatform)
    {
        if (newActivityPlatform != null)
        {
            // activate UI tutorial on first platform of run
            if (gameManager.showUITutorial)
            {
                tutorialManager.ActivateUITutorial();
            }

            // increment timeSteps
            runState.timeSteps += 1;

            // update activity history
            runState.activityHistory.Add(newActivityPlatform);
            runState.height = newActivityPlatform.y;

            // make first activity "sleep in"
            if (newActivityPlatform.activity == null)
            {
                Debug.Assert(runState.activityHistory.Count == 1);
                newActivityPlatform.activity = Object.FindObjectOfType<SleepIn>();
                runState.timeSteps = 0;
            } else
            {
                // clear out other spawnedPlatforms
                runState.ClearSpawned(newActivityPlatform);
                // trigger activity special effect
                newActivityPlatform.activity.Effect(runState);
            }
            // start new platform spawning rhythm notes
            rhythmManager.StartRhythm(newActivityPlatform.activity);
            // start activity animation
            player.GetComponent<Animator>().SetInteger("activityHash", Animator.StringToHash(newActivityPlatform.activity.name));
            player.GetComponent<Animator>().SetTrigger("startActivity");
            // hack special case increase energy from martial arts
            if (GameManager.Instance.profile.exerciseMartialArts && newActivityPlatform.activity.name == "Exercise")
            {
                runState.energy += 5;
            }
        }

        // return zoom to normal
        camera.ZoomNormal();
    }

    // for when the player enters the jump Pad
    public void EnterJumpPad(ActivityPlatform activityPlatform)
    {
        // if failed tutorial, try again
        if (runState.timeSteps == 0 && runState.rhythmCombo == 0)
        {
            gameManager.showRhythmTutorial = true;
            gameManager.StartRun();
        }
        // if done, end run (and skip the rest of the procedure)
        if (runState.done)
        {
            gameManager.EndRun(runState);
            return;
        }
        // trigger end activity animation
        player.GetComponent<Animator>().SetTrigger("finishActivity");

        // Zoom out for jump
        camera.ZoomOut();

        if (activityPlatform != null)
        {
            // stop rhythm game
            if (runState.CurrentActivityPlatform())
            {
                rhythmManager.StopRhythm();
            }
        }

        // regenerate energy - ABORTED DUE TO ENERGY = COMBO
        runState.IncreaseEnergy(gameManager.profile.energyRegen);

        // cap energy
        // runState.energy = System.Math.Min(runState.energy, gameManager.profile.energyCap);

        // DEPRECATED  - now thru thought costs/ visibility + randomized heights
        // emotions take effect on difficulty of jumping to activities
        // (by adjusting height of current platform)
        // activityPlatform.Raise(runState.GetRaiseAmount());

        // spawn new set of platforms
        List<Activity> activities = SelectActivities();
        Debug.Assert(activities.Count() < 5);
        for (int i = 0; i < activities.Count(); i++)
        {
            SpawnPlatform(activities[i], i + 1);
        }
        SpawnPlatform(SelectDefaultActivity(), 0);
        SpawnPlatform(SelectBreakdownActivity(), -1);
        // clear out all other animation triggers
        player.GetComponent<Animator>().ResetTrigger(StartJump);
        player.GetComponent<Animator>().ResetTrigger(ActivityFail);
        player.GetComponent<Animator>().ResetTrigger(StartActivity);
        player.GetComponent<Animator>().SetBool(ChantBeforeBed, GameManager.Instance.profile.meditateBeforeBed);
        player.GetComponent<Animator>().SetBool(ExerciseKick, GameManager.Instance.profile.exerciseMartialArts);
    }

    // called from player controller after sensing ready to jump
    // may be called again from thought menu if wanting to offer thoughts again
    public void PreJump()
    {
        // offer thoughts
        thoughtMenu.Activate(SelectThoughts());
        // activate thought tutorial on first platform of run
        if (gameManager.showThoughtTutorial)
        {
            tutorialManager.ActivateThoughtTutorial();
        }
    }

    // called from thought menu after selecting a thought
    public void PostThoughtSelect()
    {
        player.Jump();
    }

    // instantiate a new activity platform
    private void SpawnPlatform(Activity activity, int jumpNumber)
    {
        int yDiff = ActivityPlatform.PowerToYDiff(jumpNumber);
        GameObject platform = Instantiate(platformPrefab);
        platform.GetComponent<ActivityPlatform>().Initialize(activity, yDiff, jumpNumber);
        // add it to list of prospective platforms in runState
        runState.spawnedPlatforms.Add(platform.GetComponent<ActivityPlatform>());
    }

    private List<Activity> AvailableActivities()
    {
        // get all available normal activities, random order
        List<Activity> availableActivities = new List<Activity>();
        foreach (Activity activity in gameManager.profile.activities)
        {
            for (int i = 0; i < activity.Availability(runState); i++)
            {
                availableActivities.Add(activity);
            }
        }
        // Pick which activities to actually offer, one at a time (random order)
        return availableActivities.OrderBy(x => Random.value).ToList();
    }

    // select normal activities from pool of available
    private List<Activity> SelectActivities()
    {
        List<Activity> offeredActivities = new List<Activity>();
        List<Activity> availableActivities = AvailableActivities();
        // Put scheduled activity at front of list so it is always offered
        Activity scheduledActivity = gameManager.profile.GetSchedule(runState.timeSteps + 1);
        availableActivities.Insert(0, scheduledActivity);
        // allow multiple of the same
        for (int i = 0; i < 3; i += 1)
        {
            offeredActivities.Add(availableActivities[i]);
        }
        offeredActivities = offeredActivities.OrderBy(a => a.UnsuppressedEmotionEffect().DotProduct(runState.emotions)).ToList();
        return offeredActivities;
    }

    // select special (default, breakdown) from pool of available
    private Activity SelectDefaultActivity()
    {
        List<Activity> availableActivities = AvailableActivities();
        // one default activity
        List<Activity> defaultActivities = availableActivities.Where(a => a.IsDefault(runState)).ToList();
        Activity defaultActivity = Object.FindObjectOfType<DoNothing>();
        if (defaultActivities.Count() > 0)
        {
            // pick the default activity that suppresses the most emotion
            defaultActivity = defaultActivities.OrderBy(a => -a.TotalEmotionSupression(runState)).ToList()[0];
        }
        return defaultActivity;
    }
    private Activity SelectBreakdownActivity()
    {
        List<Activity> availableActivities = AvailableActivities();
        // lastly, add one breakdown activity
        List<Activity> breakdownActivities = availableActivities.Where(a => a.isBreakdown).ToList();
        Activity breakdownActivity = Object.FindObjectOfType<DoNothing>();
        if (breakdownActivities.Count() > 0)
        {
            breakdownActivity = breakdownActivities.OrderBy(x => Random.value).ToList()[0];
        }
        return breakdownActivity;
    }

    // select thoughts from pool of available
    private List<Thought> SelectThoughts()
    {
        // get all available thoughts
        List<Thought> availableThoughts = new List<Thought>();
        foreach (Thought thought in gameManager.profile.thoughts)
        {
            for (int i=0; i < thought.Availability(runState); i++)
            {
                availableThoughts.Add(thought);
            }
        }
        // associated thoughts are extra likely - TODO: tune, maybe use different scheme?
        if (runState.CurrentActivity())
        {
            foreach (Thought thought in runState.CurrentActivity().associatedThoughts)
            {
                for (int i = 0; i < thought.Availability(runState); i++)
                {
                    availableThoughts.Add(thought);
                }
            }
        }
            
        // if none available, return special filler thought
        if (availableThoughts.Count == 0)
        {
            // right now it's called "Nothing"
            Thought fallBack = Object.FindObjectOfType<Nothing>();
            Debug.Assert(fallBack);
            return new List<Thought> { fallBack };
        }
        // select <=3 randomly (without repeat)
        List<Thought> offeredThoughts = new List<Thought>();
        while (offeredThoughts.Count < 3 && availableThoughts.Count > 0)
        {
            int r = Random.Range(0, availableThoughts.Count);
            Thought t = availableThoughts[r];
            availableThoughts.Remove(t);
            offeredThoughts.Add(t);
        }
        return offeredThoughts;
    }

    public int RejectThoughtCost()
    {
        int emotionBonus = Mathf.Max(0, runState.emotions.Extremeness() - 1);
        int maxCost = 3 + emotionBonus;
        int cost = runState.CurrentActivityPlatform().numRejectedThoughts + 1;
        cost += emotionBonus;
        if (GameManager.Instance.profile.meditateBeforeBed)
            cost--;
        return Mathf.Min(cost, maxCost);
    }
    
    public bool IsSuppressed(EmotionType emotionType)
    {
        return runState.IsSuppressed(emotionType);
    }
}
