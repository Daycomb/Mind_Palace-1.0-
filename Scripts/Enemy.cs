using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        if (!Target)
        {
            getTarget();
        } 
        else
        {
            rotateTowardsTarget();
        }

        
    }

    private void FixedUpdate()
    {
        
    }

    private void getTarget()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void rotateTowardsTarget()
    {
        Vector2 targetDir = Target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }
}
