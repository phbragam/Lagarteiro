using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = GetClampedCameraPosition();
    }



    private void FixedUpdate()
    {
        if (transform.position.x != target.position.x)
        {
            Vector3 targetPosition = new Vector3(target.position.x,
                transform.position.y,
                transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }

    Vector3 GetClampedCameraPosition()
    {
        float xClamped = Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x);
        float yClamped = Mathf.Clamp(target.position.y, minPosition.y, maxPosition.y);
        return new Vector3(xClamped, yClamped, transform.position.z);
    }
}
