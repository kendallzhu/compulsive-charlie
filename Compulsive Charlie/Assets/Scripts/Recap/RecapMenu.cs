using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;

// Script for handling the menu after the cutScene
// (All non-ui functions called through gameManager, so it can keep track of stuff)
public class RecapMenu : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject upgradesPanel;
    public GameObject upgradesButton;
    public GameObject profileButton;
    public GameObject score;
    public GameObject activityCombos;
    public GameObject scheduleCompletion;
    private List<Upgrade> availableUpgrades;

    // Use this for initialization
    void Awake()
    {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
        // if no gameManager, load preload scene first
        if (gameManager == null)
        {
            SceneManager.LoadScene(0);
            return;
        }
        // get reference to UI elements
        upgradesPanel = transform.Find("UpgradesPanel").gameObject;
        upgradesButton = transform.Find("UpgradesButton").gameObject;
        profileButton = transform.Find("ProfileButton").gameObject;

        RunState lastRun = gameManager.profile.allRuns.Last();

        // populate score
        score.GetComponent<TextMeshProUGUI>().text = "Score: " + lastRun.score.ToString();

        // Populate activity combos
        // sort activities by best combo
        List<ActivityPlatform> history = gameManager.profile.allRuns.Last().activityHistory;
        List<ActivityPlatform> sortedHistory = history.OrderBy(ap => -ap.bestCombo).ToList();

        // retrieve name and best combos for each activity
        List<string> activityNames = sortedHistory.Select(ap => ap.activity.name).ToList();
        List<int> bestCombos = sortedHistory.Select(ap => ap.bestCombo).ToList();
        string comboStrings = "";
        for (int i = 0; i < sortedHistory.Count && i < 5; i++)
        {
            comboStrings += activityNames[i] + ": " + bestCombos[i].ToString() + "\n";
        }

        // load everything into the text box
        activityCombos.GetComponent<TextMeshProUGUI>().text = comboStrings;

        // Populate schedule completion
        // calculate schedule completion
        List<Activity> schedule = gameManager.profile.schedule;
        List<Activity> reality = lastRun.activityHistory.Select(ap => ap.activity).ToList();
        int numCompleted = 0;
        for (int i = 0; i < schedule.Count; i++)
        {
            if (i + 1 < reality.Count && schedule[i] == reality[i + 1])
            {
                numCompleted++;
            }
        }
        string completion = numCompleted.ToString() + "/" + schedule.Count.ToString();
        // load everything into the text box
        scheduleCompletion.GetComponent<TextMeshProUGUI>().text = "Schedule Completion: " + completion;

        // reset the profile after every run
        // gameManager.profile.Reset();
        GetAvailableUpgrades();
    }

    private void Update()
    {
        if (Input.GetButtonDown("start"))
        {
            ShowUpgradesPanel();
        }
        if (availableUpgrades.Count == 0)
            CloseUpgrades();
    }

    public void OnProfile()
    {
        gameManager.LoadProfile();
    }

    public void CloseUpgrades()
    {
        upgradesPanel.SetActive(false);
        gameManager.LoadProfile();
    }

    public void OnChooseUpgrade(Upgrade upgrade)
    {
        upgrade.Activate(gameManager.profile);
        if (upgrade.name == "Real Life")
            return;
        if (upgrade.singleUse)
            gameManager.profile.upgrades.Remove(upgrade);
        availableUpgrades.Remove(upgrade);
        ShowUpgradesPanel();
    }

    private void GetAvailableUpgrades()
    {
        // get available upgrades according to the category
        Profile p = gameManager.profile;
        List<Upgrade> allUpgrades = p.upgrades;
        foreach (Upgrade u in allUpgrades)
        {
            Debug.Log(u.name);
            Debug.Log(u.IsAvailable(p));
        }
        availableUpgrades = allUpgrades.Where(u => u.IsAvailable(p)).ToList();
        availableUpgrades = availableUpgrades.OrderBy(x => Random.value).ToList();
    } 

    public void ShowUpgradesPanel()
    {
        // populate the upgrade cards
        List<Transform> cards = new List<Transform> {
            upgradesPanel.transform.Find("UpgradeCard1"),
            upgradesPanel.transform.Find("UpgradeCard2"),
            upgradesPanel.transform.Find("UpgradeCard3"),
        };
        for (int i = 0; i < 3; i++)
        {
            Transform card = cards[i];
            if (i < availableUpgrades.Count())
            {
                card.gameObject.SetActive(true);
                card.GetComponent<UpgradeCard>().Initialize(availableUpgrades[i]);
            } else
            {
                card.gameObject.SetActive(false);
            }
                
        }
        upgradesPanel.SetActive(true);
    }
}
