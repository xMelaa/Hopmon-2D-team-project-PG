using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Punkt wystrzalu
    public Transform firePoint;

    // Pocisk
    public GameObject bulletPrefab;

    // Sila wystrzalu
    public float bulletForce = 20f;

    // Update sie wykonuje co klatke
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    // Funkcja odpowiedzialna za strzelanie
    private void Shoot()
    {
        // inicjalizacja nowego bulleta
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // pobranie komponentu rigidbody2d z naszego bulleta i przypisanie go do zmiennej rb
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // dodanie sily wystrzalu do naszego pocisku
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}