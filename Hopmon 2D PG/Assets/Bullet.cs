﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        Destroy(gameObject);

        if (collision.gameObject.name.Contains("Fence") ^ collision.gameObject.name.Contains("Enemy") )
        {
            Destroy(collision.gameObject);
        }
    }
}