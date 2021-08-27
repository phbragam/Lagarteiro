using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    protected DialogueManager dm;

    void Awake()
    {
        dm = FindObjectOfType<DialogueManager>();
        
    }

    private void Start()
    {
        dm.StartDialogue(dialogue);
    }


    protected virtual void Update()
    {
       
    }

    public void TriggerDialogue()
    {
        
    }
}

