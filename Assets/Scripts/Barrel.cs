using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Barrel : MonoBehaviour
{

    // get unique sound for break
    [SerializeField] AudioClip breakSound;

    // get Particle Effect for Breaking Block
    [SerializeField] GameObject blockSparkVFX;

    // track number of hits
    [SerializeField] int maxHits;

    //state vars (to view current state/debug)
    [SerializeField] int timesHit;

    // array to hold affordable damage images
    [SerializeField] Sprite[] hitSprites;

    // Cached Reference to Current Level
    Level level;


    // Cached GameSession Reference
    GameSession gameStatus;

    private void Start()
    {
        // make gamesession info available
        gameStatus = FindObjectOfType<GameSession>();

        CountBreakableBlocks();    
    }


    private void CountBreakableBlocks()
    {
        // make level info accesible to self (barrel)
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    //When somethiing hits the Barrel/Block...
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // having tagged the asset you can set rules
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        //you got me, increase count 
        timesHit++;

        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            // change image?
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        // get the nexxt image from array 
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        // PLay sound and store so it won't be destroyed
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);


        //Add to Score
        gameStatus.AddToScore();

        //Check level to determine if finished
        level.BlockDestroyed();

        //Call Particle effect
        TriggerSparkVFX();

        //...delete Me
        Destroy(gameObject);

    }

    // Function to create a Particle Effect
    private void TriggerSparkVFX()
    {
        GameObject sparkles = Instantiate(blockSparkVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

}
