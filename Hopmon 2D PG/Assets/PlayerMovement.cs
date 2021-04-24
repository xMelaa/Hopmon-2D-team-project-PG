using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject pauseMenu;
    public bool isPaused;
    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        //reakcja na escape - włączenie/wyłączenie pauzy
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                pauseMenu.SetActive(false);
                Time.timeScale = 1f; 
                isPaused = false;
            }
            else {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f; //zatrzymaj czas
                isPaused = true;
            }
        }
    }

    public void BackToMenu(){ //potrzebne do okna pauzy, skok do menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
