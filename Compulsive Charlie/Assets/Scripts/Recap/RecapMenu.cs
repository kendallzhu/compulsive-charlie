using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for handling the menu after the cutScene
// (All non-ui functions called through gameManager, so it can keep track of stuff)
public class RecapMenu : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject upgradesPanel;
    public GameObject upgradesButton;
    public GameObject profileButton;

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
        // reset the profile after every run
        gameManager.profile.Reset();
    }

    public void OnProfile()
    {
        gameManager.LoadProfile();
    }

    public void UpgradesPanel(string category = "")
    {
        if (category == "")
        {
            upgradesPanel.SetActive(false);
            upgradesButton.SetActive(false);
            profileButton.SetActive(true);
        }
        else
        {
            // populate the upgrade cards TODO: according to the category
            List<Transform> cards = new List<Transform> {
                upgradesPanel.transform.Find("UpgradeCard1"),
                upgradesPanel.transform.Find("UpgradeCard2"),
                upgradesPanel.transform.Find("UpgradeCard3"),
            };
            for (int i = 0; i < 2; i++)
            {
                Transform card = cards[i];
                card.GetComponent<UpgradeCard>().Initialize(Object.FindObjectOfType<WakeUpFresh>());
            }
            upgradesPanel.SetActive(true);
        }

    }
}
