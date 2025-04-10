using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    public Player_Stats playerstats;
    public float damage = 1;
    private Enemy_Shoottype shootType;
    private Enemy_Speedtype speedType;
   
    private void Start()
    {
        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Stats>();
        Invoke("Destroy", 10f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
           speedType = collision.gameObject.GetComponent<Enemy_Speedtype>();
            speedType.Health = speedType.Health - damage;
            
        }
        else if (collision.gameObject.CompareTag("Tank"))
        {
            shootType = collision.gameObject.GetComponent<Enemy_Shoottype>();
            shootType.Health = shootType.Health - damage;
        }
        Destroy();
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
