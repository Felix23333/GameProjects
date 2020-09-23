using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotateSpeed = 45f;
    [SerializeField] float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed, Space.World);
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var attacker = collision.gameObject;
        var health = collision.gameObject.GetComponent<Health>();
        if (attacker.tag == "Attacker" && health)
        { 
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }

}
