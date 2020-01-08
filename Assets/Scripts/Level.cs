using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    // Way of keeping track of remaining blocks
    [SerializeField] int breakableBlocks; // Serialize for Debug

    // Have a variable to cache reference the  scene
    SceneLoader sceneloader;


    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
        else
        {
            Debug.Log(breakableBlocks);
        }
    }

}
