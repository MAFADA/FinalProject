using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
