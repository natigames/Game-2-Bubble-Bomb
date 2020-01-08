using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Add this class to Manage Scenes
using UnityEngine.SceneManagement;

public class LoseColider : MonoBehaviour
{
    // when something passes through the lose colider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("GameOver");
    }
}
