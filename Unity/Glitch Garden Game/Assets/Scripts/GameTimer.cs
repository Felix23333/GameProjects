using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float levelTime = 10f;
    bool spawnFinished;
    void Update()
    {
        if(spawnFinished)
        {
            return;
        }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        spawnFinished = (Time.timeSinceLevelLoad >= levelTime);
    }
    
    public bool IsSpawnFinished()
    {
        return spawnFinished;
    }
}
