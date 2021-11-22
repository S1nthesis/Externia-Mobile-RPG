using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemyFollowController : MonoBehaviour
{
    public GameObject player;
    public float speed = 0.0001f;
    private bool facingRight = true;
    Rigidbody2D enemy;
    float xStartingPos, yStartingPos;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        xStartingPos = transform.position.x;
        yStartingPos = transform.position.y;
        enemy.gravityScale = 3.0f;
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Mathf.Abs(transform.position.x - player.transform.position.x) <= 10f);
        if (Mathf.Abs(transform.position.x - player.transform.position.x) <= 10f)
        {
            Debug.Log("hi");
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
        }
        Flip();
        //enemy.velocity = new Vector2(//Vector3.MoveTowards(transform.position,player.transform.position, 0.000001f) * -1;

        //if(enemy.velocity.x> 0 && !facingRight || enemy.velocity.x < 0 && facingRight) {
        //facingRight = !facingRight;

        //transform.Rotate(0f, 180f, 0f);
        //}

    }

    void Flip()
    {
        if (player.transform.position.x < enemy.transform.position.x && !facingRight || player.transform.position.x > enemy.transform.position.x && facingRight)
        {
            facingRight = !facingRight;

            //transform.Rotate(0f, 180f, 0f);
        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "WorldHazard")
        {
            enemy.transform.position = new Vector3(xStartingPos, yStartingPos, transform.position.z);
            enemy.velocity = new Vector3(0, 0, 0);
        }
    }

}
