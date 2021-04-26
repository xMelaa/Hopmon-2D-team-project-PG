using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public PlayerMovement player;
   public CoinPick coinPick;
    public string nextLvl;

    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement> ();
       coinPick = FindObjectOfType<CoinPick> ();

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D CoTo)
    {
        if(CoTo.name== "Player" && coinPick.teleport){
            Tel();
            SceneManager.LoadScene(nextLvl);
    }
    }

    IEnumerator Tel(){
        yield return new WaitForSeconds(4); 
    }
}
