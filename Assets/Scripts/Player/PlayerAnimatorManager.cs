using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimatorManager : MonoBehaviour
{
    public Animator anim;
    MovePlayer mp;

    public bool isWalking;
    public bool isMounted;
    public bool playerMoved;

    public Event playerFirstMoved;

    private void Awake()
    {
        playerMoved = false;
        anim = gameObject.GetComponent<Animator>();
        mp = gameObject.GetComponent<MovePlayer>();
        
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (playerMoved == false)
            {
                playerMoved = true;
                playerFirstMoved.EventOccurred();
            }

            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        anim.SetBool("IsWalking", isWalking);

        if (anim.GetBool("IsMounting") == true)
        {
            mp.enabled = false;
        }
        else
        {
            mp.enabled = true;
        }
    }

    public void Mount()
    {
        anim.SetBool("IsMounting", true);
    }
}
