
using UnityEngine;

public class Ball : MonoBehaviour
{

    //Define a field of type paddle to bind
    [SerializeField] Paddle paddle1;

    // Default values to define launch speed/Direction
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;

    // Default Audio Clip Array
    [SerializeField] AudioClip[] ballSounds;

    // Randomness to Prevent Boring Loops (linear collisions)
    [SerializeField] float randomFactor = 0.2f;

    //Define a variable to hold the distance;
    Vector2 paddleToBallVector;

    //Define a value to know if the game is On
    bool hasStarted = false;

    // Reference to Cached Component for Audio
    AudioSource myAudioSource;

    // Reference RigidBody to play with Velocity
    Rigidbody2D myRigidBody;

    void Start()
    {
        // measure distance between ball & paddle
        paddleToBallVector = transform.position - paddle1.transform.position;
        // get value for Audio Source
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        // Clicked on Primary Button (Launch)
        if (Input.GetMouseButtonDown(0))
        {
            // Flag to avoid loop
            hasStarted = true;
            // Need to access self component
            myRigidBody.velocity = new Vector2 (xPush,yPush);
            
        }
    }

    private void LockBallToPaddle()
    {
        // Calculate new position
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        // Move Ball to position   
        transform.position = paddlePos + paddleToBallVector;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Define Randomnness to Prevent Infinite Loops
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
             Random.Range(0f, randomFactor));

        // look at audio source component to play
        if (hasStarted)
        {
            // get a random audio clip from array
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            // play one shot to avoid audio cut-off
            myAudioSource.PlayOneShot(clip);

            // Add velocity randomness
            myRigidBody.velocity += velocityTweak;
        }
    }
}
