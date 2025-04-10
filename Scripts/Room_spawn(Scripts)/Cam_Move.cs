using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Move : MonoBehaviour
{
    public Camera playerCam;
    public GameObject midPoint;

    private void Start()
    {
        playerCam = Camera.main;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCam.transform.position = midPoint.transform.position + new Vector3(0, 0, -25);
        }

        
    }
}
