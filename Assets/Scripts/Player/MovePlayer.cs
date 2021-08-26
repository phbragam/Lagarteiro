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
    }

    public void UpdateSpeed()
    {
        speed = baseMountedSpeed;
    }

    

}
