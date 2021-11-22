using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBoxScript : MonoBehaviour
{

    public GameObject box;

    public Rigidbody2D rb;
    bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = box.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
            DropBox();
    }

    void DropBox()
    {
        rb.gravityScale = 3.0f;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggered = true;
        }
    }
}
