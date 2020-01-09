using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // for TextMesh

public class GameSession : MonoBehaviour
{

    // Give parameters to change Game Speed
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f;

    // Give parameters to change Block  Destroy Values
    [SerializeField] int pointsPerBlockDestroyed = 25;
    [SerializeField] int pointsPerPaddleHit = 1;

    // Hold Var to Test Autoplay
    [SerializeField] bool isAutoPlayEnabled;

    // This is how you bind it to the field
    [SerializeField] TextMeshProUGUI scoreText;

    // state variables
    [SerializeField] int currentScore = 0;

    // this happens at the very start of the script lifecycle
    // note: Score Display/Canvas  needs to move under GameStatus(UI) to
    //cascade (what to destroy or not). 
    private void Awake()
    {
        // notice the plural for SINGLETON Pattern (only 1)
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
            {
            //make inactive first (best practice)
            gameObject.SetActive(false);

            //  if one already exists and I'm number two, destroy self...
            Destroy(gameObject);
            }
        else
            {
            // Don't destroy me, I need to prevail (I'm the first)
            DontDestroyOnLoad(gameObject);
            }
    }

    // this happens once per load     
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // faster or slower
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();        
    }

     // Update score 
     public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    // We need this to remove Singleton effect (remove object in param)
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    // return true/false if enabled (note "I" for method and "i" for var)
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
