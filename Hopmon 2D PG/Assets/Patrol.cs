using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 2f; //predkosc chodzenia do ustawienia w inspektorze
    public Transform[] spots; //tablica waypointów w których enemy chodzi od jednego do drugiego
    private int spotIndex = 0; //index waypointu od ktorego enemy idzie   
    
    void Start(){        
        transform.position = spots[spotIndex].transform.position; //ustaw pozycje enemy na pozycji 1. waypointu
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    private void Move(){
        //przenies enemy z obecnego punktu na nastepny
        transform.position = Vector2.MoveTowards(transform.position, spots[spotIndex].transform.position, speed * Time.deltaTime);

        if(transform.position == spots[spotIndex].transform.position){ //jesli enemy dojdzie do punktu
            spotIndex++; //zwieksz index o 1
        }//enemy idzie do nastepnego punktu

        if(spotIndex==spots.Length){ //jesli dojdzie dddo ostatniego indexu 
            spotIndex=0; //wroc do indexu 0
        }
        
    }
}


