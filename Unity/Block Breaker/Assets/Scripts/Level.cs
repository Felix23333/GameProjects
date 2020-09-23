using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int blocks;
    SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBlocks()
    {
        blocks++;
    }

    public void BreakBlocks()
    {
        blocks--;
        if (blocks == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
