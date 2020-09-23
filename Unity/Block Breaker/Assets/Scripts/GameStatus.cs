using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    //Settings
    [Range(0f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int scorePerBlock = 1;
    [SerializeField] bool AutoPlay = false;
    
    //Reference
    [SerializeField] Text scoreText;
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();
    }

    public void AddScore()
    {
        currentScore += scorePerBlock;
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlay()
    {
        return AutoPlay;
    }
}
