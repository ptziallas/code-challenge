using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] int minX = 1;
    [SerializeField] int maxX = 15;
    [SerializeField] float screenWidthInUnits = 16;
    float mousePositionInUnits;


    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log(xaxis);
        mousePositionInUnits = (Input.mousePosition.x / Screen.width * screenWidthInUnits);
        Vector2 paddlePosition = new Vector2(transform.position.x , transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePositionInUnits, minX, maxX);
        transform.position = paddlePosition;
    }
}
