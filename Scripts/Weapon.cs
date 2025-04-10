using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public float fireForce = 20f;

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.transform.up * fireForce, ForceMode2D.Impulse);

    }

   

}
