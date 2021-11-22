using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeBox : MonoBehaviour
{
    public Sprite orangeBox;
    public Sprite blueBox;

    private SpriteRenderer spriteRenderer;
    private EdgeCollider2D ec2D;

    // Start is called before the first frame update
    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
       ec2D = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeSprite()
    {
        
        if(spriteRenderer.sprite == orangeBox)
        {
            spriteRenderer.sprite = blueBox;
            ec2D.enabled = false;
        }
        else
        {
            spriteRenderer.sprite = orangeBox;
            ec2D.enabled = true;
        }
        
    }
}
