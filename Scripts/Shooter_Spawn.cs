using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Spawn : MonoBehaviour
{
    public GameObject[] Enemies;
    
    public BoxCollider2D spawn_Area;

    private void Start()
    {
        spawn_Area = GetComponent<BoxCollider2D>();
        spawn();
        
    }

    private void Update()
    {
       
    }
   

    void spawn()
    {
        int rand = Random.Range(0, Enemies.Length);
        Bounds bounds = spawn_Area.bounds;

        Vector2 randomPosition = new Vector2(
            Random.Range(bounds.min.x, bounds.min.x),
            Random.Range(bounds.min.y, bounds.min.y)
            );



        Instantiate(Enemies[rand], randomPosition, Quaternion.identity);
        Invoke("Destroy", 0f);

    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
