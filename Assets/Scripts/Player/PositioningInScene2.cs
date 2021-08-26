using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositioningInScene2 : MonoBehaviour
{
    public VectorValue startPos;
    public VectorValue startScale;

    // Start is called before the first frame update
    void Awake()
    {
        transform.position = startPos.vectorValue;
        transform.localScale = startScale.vectorValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
