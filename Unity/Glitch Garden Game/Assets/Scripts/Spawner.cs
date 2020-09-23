using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float minPeriod = 1f;
    [SerializeField] float maxPeriod = 5f;
    [SerializeField] Attacker Attacker;
    bool spawn = true;
    // Start is called before the first frame update
    IEnumerator Start()
    {
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
 
    }

    private void SpawnAttacker()
    {
        Instantiate(Attacker, transform.position, transform.rotation);
    }
}
