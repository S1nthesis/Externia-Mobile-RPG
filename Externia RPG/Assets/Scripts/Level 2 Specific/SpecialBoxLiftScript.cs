using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBoxLiftScript : MonoBehaviour
{
    public Transform Box;
    public float BoxDisplacement;
    private Vector2 target;
    private float speed = 10.0f;
    private bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector2(Box.position.x, Box.position.y + BoxDisplacement);
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
            MoveBox();
    }

    void MoveBox()
    {
        float step = speed * Time.deltaTime;
        Box.position = Vector2.MoveTowards(Box.position, target, step);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Special")
        {
            triggered = true;
        }
    }
}
