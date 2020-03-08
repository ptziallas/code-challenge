using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] int minX;
    [SerializeField] int maxX;
    [SerializeField] float screenWidthInUnits;
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
