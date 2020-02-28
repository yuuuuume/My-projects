using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] AudioClip breakingSounds;
    [SerializeField] GameObject blockSparklesVFX;
    
    [SerializeField] Sprite[] hitSprites;

    //just for debuging purpose
    [SerializeField] int timesHit;

    // cashed reference 
   
    level level;

    //cashed reference
    GameSession GameStatus;

    private void Start()
    {
        CountBreakableBlocks();

        GameStatus = FindObjectOfType<GameSession>();
    }

    private void CountBreakableBlocks()
    {
        //we need to access to the type of level
        //all instances are adding another block so that why it can count the number of blocks.
        level = FindObjectOfType<level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    //we need param to be of collision 2d
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit();

    }

    private void HandleHit()
    {
        timesHit++;
        int maxHit = hitSprites.Length + 1;

        if (tag == "Breakable")
        {
            //might be the situation which skip the equal condition. avoid bug!!
            if (timesHit >= maxHit)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1 ;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }

        else
        {
            Debug.LogError("missing array " + gameObject.name);

        }
        }


    private void DestroyBlock()
    {
        TriggerSparklesVFX();
        AudioSource.PlayClipAtPoint(breakingSounds, Camera.main.transform.position);
        //Object.Destroy has two params time and object
        Destroy(gameObject);
        level.BlockDestroyed();
        GameStatus.Add2Score();
        //Debug.Log(collision.gameObject.name);
    }

    private void TriggerSparklesVFX()
    {
        //position where you are currentry on.
        GameObject sparkles = Instantiate(blockSparklesVFX,transform.position, transform.rotation);
        Destroy(sparkles, 0.1f);
    }


}
