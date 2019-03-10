using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawn : MonoBehaviour
{
    // public GameObject noteSpawner; noteSpawner is parent of this script
    public GameObject note1;
    //public GameObject note2;

    int id_ = 1;
    Vector3 startingPos;    

    void Start()
    {
        GameObject staffPos = GameObject.FindWithTag("StaffBkgd");
        startingPos.x = staffPos.transform.position.x + 16f; // WARNING (MAGIC NUMBER): just to the right of the camera
        startingPos.y = staffPos.transform.position.y;
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject note = Instantiate(note1, startingPos, Quaternion.identity, transform.parent);
            note.GetComponent<Note>().id = id_;     // each note must have the "Note" script as a component
            note.GetComponent<Note>().noteType = 1;

            id_++;
        }
	}
}
