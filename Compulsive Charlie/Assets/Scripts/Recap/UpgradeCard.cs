﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeCard : MonoBehaviour
{
    public GameManager gameManager;
    public RecapMenu recapMenu;
    // icons
    public GameObject energyIcon;
    public GameObject emotionIcon;
    public GameObject thoughtIcon;
    public GameObject actionIcon;

    public Upgrade upgrade;
    // Start is called before the first frame update
    void Start()
    {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
        // get reference to recap menu script
        recapMenu = transform.parent.parent.GetComponent<RecapMenu>();
    }

    // set the display of hte card
    public void Initialize(Upgrade _upgrade)
    {
        upgrade = _upgrade;
        GameObject nameText = transform.Find("NameText").gameObject;
        nameText.GetComponent<TextMeshProUGUI>().text = upgrade.name;
        energyIcon.SetActive(false);
        emotionIcon.SetActive(false);
        thoughtIcon.SetActive(false);
        actionIcon.SetActive(false);
        if (upgrade.category == "energy")
        {
            energyIcon.SetActive(true);
        }
        else if (upgrade.category == "emotion")
        {
            emotionIcon.SetActive(true);
        }
        else if (upgrade.category == "thought")
        {
            thoughtIcon.SetActive(true);
        }
        else if (upgrade.category == "action")
        {
            actionIcon.SetActive(true);
        }
    }

    // Update is called once per frame
    public void OnClick()
    {
        if (upgrade)
        {
            upgrade.Activate(gameManager.profile);
        }
        // move to next upgrade category
        recapMenu.CloseUpgrades();
        return;
    }
}
