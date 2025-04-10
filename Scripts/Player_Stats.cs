using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Stats : MonoBehaviour
{
    public float lives = 100;
    public float dash ;
    public float level_attempts =0f;
    public bool keep_stats;
    public bool endpoint;
    
    private void Update()
    {
        if (lives <= 0)
        {
            endGame();
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("End"))
        {
            endpoint = true;
            nextLevel();
        }
    }

    void nextLevel()
    {
        if (level_attempts <= 3)
        {
            if (endpoint == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                endpoint = false;
            }
            
        }
        
        
    }

    void endGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
