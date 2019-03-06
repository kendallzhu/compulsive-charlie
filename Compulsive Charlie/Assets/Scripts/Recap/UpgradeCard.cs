using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeCard : MonoBehaviour
{
    public GameManager gameManager;
    public Upgrade upgrade;
    // Start is called before the first frame update
    void Start()
    {
        // get reference to gameManager
        gameManager = Object.FindObjectOfType<GameManager>();

        // test
        Initialize(Object.FindObjectOfType<WakeUpFresh>());
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
        upgrade.Activate(gameManager.profile);
        Destroy(gameObject);
        return;
    }
}
