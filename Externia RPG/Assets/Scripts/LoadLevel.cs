using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.transform.position = new Vector3(-9.1f, 0.42f, 0f);
            LoadScene();
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
