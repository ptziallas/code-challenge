using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle;
    [SerializeField] Vector2 startingBallSpeed;

    Vector2 paddleToBallVector;
    Vector2 paddlePosition;
    bool hasStarted;
    bool hasLaunched;

    void Start()
    {
        hasStarted = false;
        paddleToBallVector = transform.position - paddle.transform.position;
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

}
