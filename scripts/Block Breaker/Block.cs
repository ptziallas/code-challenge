using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    Level level;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int timesHit; //serialized for debug
    [SerializeField] Sprite[] hitSprites;
    //GameStatus gameStatus; 1

    public void Start()
    {
        CoumtBreakableBlocks();
    }

    private void CoumtBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        //gameStatus = FindObjectOfType<GameStatus>(); 1
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1; // isws dhlwsh ektos
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;  // dhlwsh ektos
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name); // testing
        }
    }

    private void DestroyBlock()
    {
            FindObjectOfType<GameStatus>().AddToScore(); //1
            //gameStatus.AddToScore(); 1
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            Destroy(gameObject);
            level.BlockDestroyed();
            TriggerSparklesVFX();       
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX , transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }


}
