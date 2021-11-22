using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 100;

    public void TakeDamage(int damageTaken) {
        enemyHealth -= damageTaken;

        if(enemyHealth <= 0) {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }
}
