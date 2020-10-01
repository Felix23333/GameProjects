using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frozen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        float currentspeed = attacker.GetMovementSpeed();
        attacker.SetMovementSpeed(currentspeed / 2);
    }
}