using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public GameObject[] Enemies;
    public float waveNum;
    public BoxCollider2D spawn_Area;

    private void Start()
    {
        spawn_Area = GetComponent<BoxCollider2D>();
        waveNum = 0;
        Invoke("waves", 0f);
    }

    private void Update()
    {
        if (waveNum >= 3)
        {
            Destroy(this.gameObject);
        }
    }
    void waves()
    {
        Invoke("spawn", 3f);
        waveNum++;
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
        Invoke("waves", 0f);

    }
}
