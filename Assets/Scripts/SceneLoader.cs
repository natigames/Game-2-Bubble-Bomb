using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        // get Scene from Build order
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    public void LoadStartScene()
    {
        // Go to first of array
        SceneManager.LoadScene(1);

        //Reset the game to remove SCORE persistance
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        // Close
        Application.Quit();
    }

}
