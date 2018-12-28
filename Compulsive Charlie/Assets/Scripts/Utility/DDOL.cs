using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for making things persistent accross scenes
// (used for objects in preload scene such as gameManager)
public class DDOL : MonoBehaviour {
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
