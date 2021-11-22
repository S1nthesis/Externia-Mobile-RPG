using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector2 bulletSpeed;
    public int bulletDamage = 40;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = bulletSpeed;
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);

        Enemy enemyHit = other.gameObject.GetComponent<Enemy>();
        if(enemyHit != null) {
            enemyHit.TakeDamage(bulletDamage);  
        }
    }
}
