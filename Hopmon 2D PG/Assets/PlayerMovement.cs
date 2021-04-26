﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool isPaused;
    
    public GameObject pauseMenu;
    public Animator animator;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    private Vector2 moveDirection;
    private Vector2 movement;
    private Vector2 mousePos;
    private Vector2 lookDir;

    // Update is called once per frame
    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        moveDirection = new Vector2(moveX, moveY).normalized;
        Animate();
        
        

        //reakcja na escape - włączenie/wyłączenie pauzy
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f; //zatrzymaj czas
                isPaused = true;
            }
        }
    }

    void Animate(){
        if (moveDirection != Vector2.zero){ //warunek który sprawia ze postac zostaje w tym samym kierunku co szla
            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);
        }
        
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }



    public void BackToMenu()
    { //potrzebne do okna pauzy, skok do menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}