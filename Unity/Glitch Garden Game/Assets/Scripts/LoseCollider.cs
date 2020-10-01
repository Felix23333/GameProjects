using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] Text liveDisplay;
    [SerializeField] float damage = 1f;
    [SerializeField] GameObject loseCanvas;

    float health;
    private void Awake()
    { 
        if (PlayerRefController.GetGameDifficulty() == 1f)
        {
            return;
        }
        else if(PlayerRefController.GetGameDifficulty() == 2f)
        {
            GetComponent<Health>().SetMaxHealth(5f);
        }
        else if(PlayerRefController.GetGameDifficulty() == 3f)
        {
            GetComponent<Health>().SetMaxHealth(1f);
        }
    }
    private void Start()
    {
        UpdateLives();
        loseCanvas.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        GetComponent<Health>().DealDamage(damage);
        UpdateLives();

        if (health <= 0)
        {
            LoseGame();
        }
    }

    private void LoseGame()
    {
        Time.timeScale = 0;
        loseCanvas.SetActive(true);
    }

    private void UpdateLives()
    {
        health = GetComponent<Health>().GetCurrentHealth();
        liveDisplay.text = health.ToString();
    }
}
