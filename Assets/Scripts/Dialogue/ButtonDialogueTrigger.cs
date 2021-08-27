using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDialogueTrigger : DialogueTrigger
{
    // event needs to be injected in the system where it will happen
    public Event playerApproached;
    public Event playerWalkedAway;
    public Dialogue proximityDialogue;
    bool playerInRange;

    protected override void Start()
    {
        base.Start();
        playerInRange = false;
        dialogue = proximityDialogue;
    }

    protected override void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange && !dm.isDialogueRunning)
        {
            Invoke("TriggerDialogue", .1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerApproached.EventOccurred();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerWalkedAway.EventOccurred();
            playerInRange = false;
            dm.EndDialogue();
        }
    }
}
