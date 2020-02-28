
using UnityEngine;

public class ball : MonoBehaviour
{   //config param
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 16f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    //state 
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    // Start is called before the first frame update

    //Cashed component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;



    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
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
        if (Input.GetMouseButtonDown(0))
        {
            //velocity needs x and y
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2 (xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 velocityTweak = new Vector2
            (Random.Range(0f,randomFactor),
            Random.Range(0f,randomFactor) );
        //not affected by paddle
        if (hasStarted)
        {
           //to make sure where is the random fun
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            //even if you touch the another collision it finish the current sound
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
