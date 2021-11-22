using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    public float horizontalSpeed;
    public float verticalSpeed;
    public float dashSpeed;

    private int direction;

    public GameObject bulletLeft, bulletRight;

    public float startingHealth;

    public HealthBarScript healthBar;

    bool facingRight, jumping, running, onGround, canDash, canAttack, isShooting;

    public float attackRate = 2f;
    float speed, nextAttackTime, health;

    Animator anim;
    Rigidbody2D rb;
    Transform shootPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StopMoving();
        health = startingHealth;
        healthBar.SetMaxHealth(startingHealth);
        anim = GetComponent<Animator>();
        shootPosition = transform.Find("initialBullet");
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(speed);
        Flip();
        ResetAttackTime();
        isDead();
        
    }

    void Flip() {
        if(speed > 0 && !facingRight || speed < 0 && facingRight) {
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }

    void isDead()
    {
        if (health <= 0 || transform.position.y < -30)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //transform.position = new Vector3(-9.1f, 0.42f, 0f);
            //health = startingHealth;
        }
    }

    void MovePlayer(float playerSpeed)
    {
        if (Mathf.Abs(speed) != dashSpeed)
        {
            if (!isShooting && (playerSpeed < 0 && !jumping || playerSpeed > 0 && !jumping))
                anim.SetInteger("PlayerState", 1);
            if (!isShooting && (playerSpeed == 0 && !jumping))
                anim.SetInteger("PlayerState", 0);
        }
        else
            anim.SetInteger("PlayerState", 4);
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground" && rb.velocity.y <= 0) {
            onGround = true;
            jumping = false;
            canDash = true;
        }
        if(other.gameObject.tag == "WorldHazard") {
            health -= 10;
        }
        if(other.gameObject.tag == "Enemy") {
            onGround = true;
            jumping = false;
            health -= 10;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && rb.velocity.y <= 0)
        {
            onGround = true;
            jumping = false;
            //canDash = true;
        }
        if (other.gameObject.tag == "WorldHazard")
        {
            onGround = true;
            jumping = false;
            health -= 4;
            healthBar.SetHealth(health);
        }

        if (other.gameObject.tag == "Enemy") {
        
            health--;
            healthBar.SetHealth(health);
        }
    }

    /*void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Ground") {
            onGround = false;
            // = false;
            //canDash = true;
        }
    }*/

    public void MoveLeft() {
        if(Mathf.Abs(speed) != dashSpeed)
            speed = -horizontalSpeed;
    }
    
    public void MoveRight() {
        if(Mathf.Abs(speed) != dashSpeed)
            speed = horizontalSpeed;
    }

    public void StopMoving() {
        if (Mathf.Abs(speed) != dashSpeed)
        {
            rb.gravityScale = 3.0f;
            speed = 0;
        }
    }

    public void DashStopMoving()
    {
        rb.gravityScale = 3.0f;
        speed = 0;
    }
    
    public void Dash() {
        if(canDash) {
            canDash = false;
            rb.gravityScale = 0.0f;
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);

            if(facingRight) {
                speed = dashSpeed;
            } else if(!facingRight) {
                speed = -dashSpeed;
            }
            Invoke("DashStopMoving", 0.4f);
        }
    }
    public void Jump() {
        if(onGround && rb.gravityScale == 3.0f && rb.velocity.y <= .1f && rb.velocity.y >= -.1f) {
            jumping = true;
            onGround = false;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(new Vector2(rb.velocity.x, verticalSpeed), ForceMode2D.Impulse);
            anim.SetInteger("PlayerState", 2);
            //rb.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        }
    }


    public void Shoot() {
        if(canAttack) {
            anim.SetInteger("PlayerState", 3);
            if(facingRight)
                Instantiate(bulletRight, shootPosition.position, Quaternion.identity);
            if(!facingRight)
                Instantiate(bulletLeft, shootPosition.position, Quaternion.identity);
            canAttack = false;
            nextAttackTime = Time.time + 1f / attackRate;
            isShooting = true;
        }
    }

    void ResetAttackTime() {
        if(!canAttack)
            if(Time.time >= nextAttackTime) {
                canAttack = true;
                isShooting = false;
        }

    }


}
