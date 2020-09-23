using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip[] breakSounds;
    [SerializeField] GameObject destoryVFX;
    [SerializeField] int maxHit = 3;
    [SerializeField] Sprite[] damageLevel;

    //Reference
    Level level;
    GameStatus gameStatus;
    int currentHit;

    private void Start()
    {
        ReadLevel();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            currentHit++;
            if(currentHit >= maxHit)
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
        gameObject.GetComponent<SpriteRenderer>().sprite = damageLevel[currentHit];
    }

    private void TriggerVFX()
    {
        GameObject sparkles = Instantiate(destoryVFX, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(sparkles, 0.5f);
    }

    private void ReadLevel()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void DestroyBlock()
    {
        AudioClip breakSound = breakSounds[UnityEngine.Random.Range(0, breakSounds.Length)];
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.BreakBlocks();
        gameStatus.AddScore();
        TriggerVFX();
        Destroy(gameObject);
    }
}
