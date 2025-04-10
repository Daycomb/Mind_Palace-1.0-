using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Spawn : MonoBehaviour
{
    public GameObject[] objects;

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
        int rand = Random.Range(0, objects.Length);
        



        Instantiate(objects[rand], transform.position, Quaternion.identity);
        Invoke("Destroy", 0f);

    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
