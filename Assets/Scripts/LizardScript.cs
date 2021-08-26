using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardScript : MonoBehaviour
{
    public Animator anim;
    public Event playerMounted;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        playerMounted.EventOccurred();
    }

    public void OnPlayerFirstMoved()
    {
        anim.SetTrigger("WakeUp");
    }
}
