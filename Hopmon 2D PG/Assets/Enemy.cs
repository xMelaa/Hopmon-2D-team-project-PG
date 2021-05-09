using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public PlayerMovement pl; //bedziemy korzystac z innego pliku cs

    // wywolane na samym poczatku
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        pl = FindObjectOfType<PlayerMovement>();
    }

    // Update przy kazdej klatce (tutaj na bierząco są wykonywane obliczenia potrzebne do ustalenia nowych parametrów ruchu)
    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        // Tutaj wykonywana jest funkcja odpowiedzialna za ciągły ruch przeciwników
        moveCharacter(movement);
    }

    private void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            pl.energy(-1);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    { // jesli trigger jest aktywowany
        if (col.name == "Player")
        { // jesli kolizja jest z Playerem
            pl.energy(-1); // wywolaj funkcje dodajaca energie z wartoscia -1 (odejmuje)
        }
    }
}