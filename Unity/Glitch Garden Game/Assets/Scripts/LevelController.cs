using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    Attacker[] Attackers;
    GameTimer gameTimer;
    [SerializeField] GameObject winCanvas;
    [SerializeField] float waitToLoad = 3f;
    bool isWin = false;
    // Start is called before the first frame update
    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        winCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Attackers = FindObjectsOfType<Attacker>();
        TestWinCondition();
    }

    private void TestWinCondition()
    {
        if (gameTimer.IsSpawnFinished() && Attackers.Length == 0 && !isWin)
        {
            isWin = true;
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winCanvas.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }
}
