using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoottype : MonoBehaviour
{
    public Transform Target;
    public float Health = 3f;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    public Weapon weapon;
    public Counter_Enemy enemycount;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponent<Weapon>();
        
        shoot();
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
        if (Health <= 0)
        {
           
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

    public void shoot()
    {
        weapon.Fire();
        Invoke("reload", 0f);
        Debug.Log("SHOT");
    }

    public void reload()
    {
        Invoke("shoot", 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("PlayerDamage"))
        {
            Health--;
        }
    }

}
