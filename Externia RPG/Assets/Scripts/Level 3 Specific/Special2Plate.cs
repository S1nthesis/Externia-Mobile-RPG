using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special2Plate : MonoBehaviour
{
    public GameObject firstBox, secondBox, thirdBox, fourthBox;

    LevelThreeBox one, two, three, four;
    // Start is called before the first frame update
    void Start()
    {
        one = firstBox.GetComponent<LevelThreeBox>();
        two = secondBox.GetComponent<LevelThreeBox>();
        three = thirdBox.GetComponent<LevelThreeBox>();
        four = fourthBox.GetComponent<LevelThreeBox>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            one.ChangeSprite();
            two.ChangeSprite();
            three.ChangeSprite();
            four.ChangeSprite();
        }
    }
}
