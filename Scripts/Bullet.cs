using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Player_Stats playerstats;
    private void Start()
    {
        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Stats>();
        Invoke("Destroy", 10f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerstats.lives--;
        }
        Destroy();
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
