using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new vector value", menuName = "SO Variables/Vector Value")]
public class VectorValue : ScriptableObject
{
    //editor values 
    [SerializeField]
    private Vector2 defaultVectorValue;

    [Header("Runtime value")]
    public Vector2 vectorValue;

    private void OnEnable()
    {
        vectorValue = defaultVectorValue;
    }
}
