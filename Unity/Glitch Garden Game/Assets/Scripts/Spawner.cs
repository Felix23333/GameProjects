using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float minPeriod = 1f;
    [SerializeField] float maxPeriod = 5f;
    [SerializeField] Attacker[] Attackers;
    GameTimer gameTimer;
    bool spawn = true;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        while (spawn)
        {
            float spawnPeriod = Random.Range(minPeriod, maxPeriod);
            yield return new WaitForSeconds(spawnPeriod);
            SpawnAttacker();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameTimer.IsSpawnFinished() && spawn)
        {
            StopSpawn();
        }
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate(RandomSpawn(), transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    private Attacker RandomSpawn()
    {
        int index = Attackers.Length;
        return Attackers[Random.Range(0, index)];
    }

    private void StopSpawn()
    {
        spawn = false;
    }
}
