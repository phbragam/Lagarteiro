using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDialogueTrigger : DialogueTrigger
{
    public Dialogue proximityDialogue;

    protected override void Start()
    {
        base.Start();
        dialogue = proximityDialogue;
    }

    protected override void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TriggerDialogue();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dm.EndDialogue();
    }
}