using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] int resourceCost = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    public void GenerateResource(int resourceAmount)
    {
        FindObjectOfType<ResourceDisplay>().AddResources(resourceAmount);
    }
}
