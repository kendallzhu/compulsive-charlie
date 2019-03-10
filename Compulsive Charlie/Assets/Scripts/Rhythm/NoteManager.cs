using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public List<GameObject> notes;
    public List<float> timings;

    public float window; // how generous should we be

    public void DestroyNote()
    {
        Destroy(notes[0]);
        notes.RemoveAt(0);
        timings.RemoveAt(0);
    } 
}
