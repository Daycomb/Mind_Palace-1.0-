using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tele_Check : MonoBehaviour
{
    public GameObject Teleport_Entrance;
    public Teleport teleport;

    public float waittime = 4f;
    public float invokeTime = 2f;
    public Vector2 dir;
    private void Start()
    {
        teleport = Teleport_Entrance.GetComponent<Teleport>();
        
        
        Destroy(gameObject, waittime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tele"))
        {
            teleport.can_Tele = true;

        }
    }

   

    

 
}
