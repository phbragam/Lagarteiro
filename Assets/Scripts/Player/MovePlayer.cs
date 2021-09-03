using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    private Rigidbody2D rb;
    private float distance;
    public float speed;
    public float baseSpeed;
    public float baseMountedSpeed;
    public AudioSource rideSound;
    public AudioSource walkSound;

    // Start is called before the first frame update
    void Start()
    {
        // speed = baseSpeed;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        distance = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rb.MovePosition(rb.position + new Vector2(distance, 0));

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 && speed == baseMountedSpeed)
        {
            if (rideSound.isPlaying == false)
            {
                rideSound.Play();
            }
            walkSound.Stop();
        }
        else if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 && speed == baseSpeed)
        {
            if (walkSound.isPlaying == false)
            {
                walkSound.Play();
            }
            rideSound.Stop();
        }
        else
        {
            rideSound.Stop();
            walkSound.Stop();
        }
    }

    public void UpdateSpeed()
    {
        speed = baseMountedSpeed;
    }

    private void OnDisable()
    {
        rideSound.Stop();
        walkSound.Stop();
    }



}
