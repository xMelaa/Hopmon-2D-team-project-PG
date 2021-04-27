using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Vector2 movement;
    //public PlayerMovement pl; //bedziemy korzystac z innego pliku cs

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //pl = FindObjectOfType<PlayerMovement> ();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    /*void OnTriggerEnter2D(Collider2D col){ // jesli trigger jest aktywowany
        if(col.name == "Player"){ // jesli colizja jest z Playerem
            pl.energy (-1); // wywolaj funkcje dodajaca energie z wartoscia -1 (odejmuje)
        }
    }*/
}