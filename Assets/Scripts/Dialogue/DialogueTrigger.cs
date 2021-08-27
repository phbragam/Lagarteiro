using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    protected Dialogue dialogue;
    protected DialogueManager dm;

    protected virtual void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
    }


    protected virtual void Update()
    {
       
    }

    public void TriggerDialogue()
    {
        dm.StartDialogue(dialogue);
    }
}

