using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad;
    public VectorValue spawnPoint;
    public VectorValue scale;

    public Vector2 newSpawnPoint;
    public Vector2 newScale;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(sceneToLoad);
        spawnPoint.vectorValue = newSpawnPoint;
        scale.vectorValue = newScale;
    }

}


