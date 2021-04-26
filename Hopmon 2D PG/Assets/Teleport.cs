using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public PlayerMovement player;
   public CoinPick coinPick;
    public string nextLvl;

    
    void Start()
    {
        player = FindObjectOfType<PlayerMovement> ();
       coinPick = FindObjectOfType<CoinPick> ();

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D CoTo) //jesli wejdzie na pole
    {
        if(CoTo.name== "Player" && coinPick.teleport){ //jesli colider to player i teleport jest true           
            SceneManager.LoadScene(nextLvl); //przenies na nastepna scene
            
    }
    }

    
}
