using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject destination;
    public GameObject Player;
    public GameObject door;
    public bool can_Tele;

    

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Player"))
        {
            if (can_Tele == true)
            {
                Tele();
            }
            
            
        }
    }
   
    public void Tele()
    {
        Player.transform.position = destination.transform.position;
    }
    

}
