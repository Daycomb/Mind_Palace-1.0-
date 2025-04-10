using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Speedtype : MonoBehaviour
{
    public Transform Target;
    public float Health = 2f;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    public Player_Stats Pl_Lives;
    public Counter_Enemy enemycounter;

    private void Start()
    {
        enemycounter = GameObject.FindGameObjectWithTag("EnemyCount").GetComponent<Counter_Enemy>();
        Pl_Lives = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Stats>();
        rb = GetComponent<Rigidbody2D>();
        if (CompareTag("Tank"))
        {
            Health = 5;
            Debug.Log("TANNNNNNNNNNNNNK");
        }
        else
        {
            Health = 2;
        }
        
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
        rb.velocity = transform.up * speed;

        if (Health <= 0)
        {
            enemycounter.enemyCount--;
            Destroy(this.gameObject);
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Pl_Lives.lives--;
            Debug.Log("Hit");
        }

        if (collision.gameObject.CompareTag("PlayerDamage"))
        {
            Health--;
        }
    }

    
}
