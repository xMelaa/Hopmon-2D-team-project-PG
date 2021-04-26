using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public PlayerMovement player;
    public string nextLvl;

    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement> ();

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D CoTo)
    {
        if(CoTo.name== "Player"){
            SceneManager.LoadScene(nextLvl);
    }
    }
}
