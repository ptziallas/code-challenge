using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle;
    [SerializeField] Vector2 startingBallSpeed = new Vector2(2f , 10f); // aparetito to =?
    [SerializeField] AudioClip[] ballSounds;

    Vector2 paddleToBallVector;
    Vector2 paddlePosition;
    bool hasStarted;
    bool hasLaunched;
    AudioClip clip;
    AudioSource myAudioSource;

    void Start()
    {
        hasStarted = false; //maybe before void start()
        paddleToBallVector = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }
    
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
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(startingBallSpeed.x , startingBallSpeed.y);
        }
    }

    private void LockBallToPaddle()
    {
        paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            clip = ballSounds[Random.Range(0 , ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }

}
