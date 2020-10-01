using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] int resourceCost = 50;

    Spawner mySpawner;
    Animator animator;
    GameObject projectileParent;
    // Start is called before the first frame update
    void Start()
    {
        CreateProjectileParent();
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find("Projectiles");
        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
    }

    private void SetLaneSpawner()
    {
        Spawner[] spanwers = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spanwers)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(IsCloseEnough)
            {
                mySpawner = spawner;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (AttackIsInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    private bool AttackIsInLane()
    {
        if (mySpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        Projectile newProjectile = Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
        newProjectile.transform.parent = projectileParent.transform;
    }

    public void GenerateResource(int resourceAmount)
    {
        FindObjectOfType<ResourceDisplay>().AddResources(resourceAmount);
    }

    public int GetResourceCost()
    {
        return resourceCost;
    }
}
