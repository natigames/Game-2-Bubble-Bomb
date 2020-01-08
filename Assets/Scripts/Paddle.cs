using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // Initialize  based on camera position 
    [SerializeField] float screenWidthInUnits = 22f;

    // Define movement Range
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 21f;


    // get Particle Effect for Breaking Block
    [SerializeField] GameObject paddleSparkVFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Where am I - as% (relative to the screen size) times view units?
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        //Use vector2 var to locate Paddle (only X will be used, y remains)
        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);

        // Make sure the paddle doesn't go offscreen
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);

        //Now move he paddle
        transform.position = paddlePos;
    }


    //When somethiing hits the Paddle
    private void OnCollisionEnter2D(Collision2D collision)
    {
            TriggerSparkVFX();
    }

    // Function to create a Particle Effect
    private void TriggerSparkVFX()
    {
        GameObject sparkles = Instantiate(paddleSparkVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }



}
