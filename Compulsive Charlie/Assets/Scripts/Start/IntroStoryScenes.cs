using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Start
{
    public class IntroStoryScenes : MonoBehaviour
    {
        private List<GameObject> scenes;
        private int currentSceneIndex;
        private List<TextMeshProUGUI> texts;
        private int currentTextIndex;
        
        private void Start()
        {
            if (GameManager.Instance == null)
                SceneManager.LoadScene("Preload");
            scenes = new List<GameObject>();
            // initialize list of scenes
            foreach (Transform child in transform)
            {
                scenes.Add(child.gameObject);
            }
            // initialize text objects for first scene
            texts = new List<TextMeshProUGUI>();
            foreach (TextMeshProUGUI text in scenes[0].GetComponentsInChildren<TextMeshProUGUI>())
            {
                texts.Add(text);
            }
            RefreshDisplay();
        }

        private void Update()
        {
            if (Input.anyKeyDown)
            {
                Advance();
            }
        }

        private void RefreshDisplay()
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                GameObject scene = scenes[i];
                scene.SetActive(i == currentSceneIndex);
            }
            for (int i = 0; i < texts.Count; i++)
            {
                GameObject text = texts[i].gameObject;
                text.SetActive(i == currentTextIndex);
            }
        }

        public void Advance()
        {
            currentTextIndex++;
            if (currentTextIndex >= texts.Count)
            {
                AdvanceScene();
            }
            RefreshDisplay();
        }

        public void AdvanceScene()
        {
            currentSceneIndex++;
            currentTextIndex = 0;
            if (currentSceneIndex >= scenes.Count)
            {
                SceneManager.LoadScene("Start");
            }
            // load children of scene
            texts = scenes[currentSceneIndex].transform.GetComponentsInChildren<TextMeshProUGUI>().ToList();
            RefreshDisplay();
        }
    }
}