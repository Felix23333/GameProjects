using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 50f;
    [SerializeField] float currentHealth;
    [SerializeField] GameObject deathVFX;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);   
        }
    }

    private void TriggerDeathVFX()
    {
        if(!deathVFX)
        {
            return;
        }
        GameObject deathVFXObj = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObj, 0.5f);
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetMaxHealth(float health)
    {
        maxHealth = health;
    }

    /*public bool IsDead()
    {
        if(currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/
}
