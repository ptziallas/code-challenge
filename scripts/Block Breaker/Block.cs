using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    Level level;
    //GameStatus gameStatus; 1

    public void Start()
    {
        level = FindObjectOfType<Level>();
        //gameStatus = FindObjectOfType<GameStatus>(); 1
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().AddToScore(); //1
        //gameStatus.AddToScore(); 1
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
    }

}
