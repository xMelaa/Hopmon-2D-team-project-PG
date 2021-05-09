using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Usuwanie bulleta przy kolizji
        Destroy(gameObject);

        if (collision.gameObject.name.Contains("Fence") ^ collision.gameObject.name.Contains("Enemy"))
        {
            // Usuwanie enemy/fence przy kolizji
            Destroy(collision.gameObject);
        }
    }
}