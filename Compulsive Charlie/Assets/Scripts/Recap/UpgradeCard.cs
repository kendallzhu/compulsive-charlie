using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeCard : MonoBehaviour
{
    public GameManager gameManager;
    public RecapMenu recapMenu;

    public Upgrade upgrade;
    // Start is called before the first frame update
    void Start()
    {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();
        // get reference to recap menu script
        recapMenu = transform.parent.parent.GetComponent<RecapMenu>();
    }

    // correctly position platform based on current states
    public void Initialize(Upgrade _upgrade)
    {
        upgrade = _upgrade;
        GameObject nameText = transform.Find("NameText").gameObject;
        nameText.GetComponent<TextMeshProUGUI>().text = upgrade.name;
    }

    // Update is called once per frame
    public void OnClick()
    {
        if (upgrade)
        {
            upgrade.Activate(gameManager.profile);
        }
        // move to next upgrade category
        recapMenu.UpgradesPanel("");
        return;
    }
}
