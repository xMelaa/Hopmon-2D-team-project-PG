using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool isPaused;

    public GameObject pauseMenu;
    public GameObject deathMenu;
    public Animator animator;

    public float moveSpeed = 5f;

    public Rigidbody2D rb; // referencja do komponentu rigidbody2d naszego bohatera
    public Camera cam; // referencja do wybranej kamery

    public float energia = 1;
    private Vector2 moveDirection; // kierunek poruszania
    private Vector2 mousePos; // pozycja myszki
    private Vector2 lookDir; // kierunek, w którym patrzy nasz bohater

    // Update is called once per frame
    private void Update()
    {
        Time.timeScale = 1f;
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // inicjalizacja pozycji myszki
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // inicjalizacja kierunku poruszania
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
        if (energia < 1)
        {
            deathMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void Animate()
    {
        if (moveDirection != Vector2.zero)
        { //warunek który sprawia ze postac zostaje w tym samym kierunku co szla
            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);
        }

        // ustawiamy kwadratową długość wektora, dzięki czemu nasza prędkość bohatera jest taka sama gdy poruszamy się po skosie
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }

    public void energy(int wartosc)
    {
        energia = energia + wartosc; //dodawanie wartosci do energii
        Debug.Log("x");
    }

    public void BackToMenu()
    { //potrzebne do okna pauzy, skok do menu
        SceneManager.LoadScene(0);
    }

    public void ResetLevel()
    { //potrzebne do okna pauzy, skok do menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void FixedUpdate()
    {
        // ustawienie predkosci
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        // ustawienie kierunku patrzenia bohatera
        lookDir = mousePos - rb.position;

        // wyliczenie odpowiedniego katu
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        // rotacja bohatera o ten kąt, aby model naszego bohatera faktycznie patrzyl sie w kierunku kursora
        rb.rotation = angle;
    }
}