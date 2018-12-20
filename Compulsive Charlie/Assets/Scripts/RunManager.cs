using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager gameManager = Object.FindObjectOfType<GameManager>();
        Debug.Log(gameManager);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
