using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinPick : MonoBehaviour
{
        
    public bool teleport = false;    
        //Aktualna ilość punktów
    private int coin = 0;
    private int coinAct = 0;
        //Tutaj wpisujemy max pktów za konkretny poziom
    private int coin1LVL = 10;
    private int coin2LVL = 26;
    private int coin3LVL = 24;
        //Pobieramy muzykę do coinSound
    public AudioClip coinSound;
        //Głośność muzyki
    public float volume;
        //Pobieramy TextMeshPro do textCoins
    public TextMeshProUGUI textCoins;
        //W trakcie kolizji, algorytm sam wylicza ile jest i ile powinno być punktów, nie trzeba zmieniać
    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Coins")
            {
                    //powiększ coin o 1
                coin++;
                coinAct++;
                if(coinAct >= 0 && coinAct < coin1LVL){//zmien wczesniej wybrany TextMeshPro na Tekst + ilość punktów zamienionych na string
                    textCoins.text = coin.ToString() + " / " + coin1LVL;
                }
                    //TO BĘDZIE DO ZMIANY
                if(coinAct >= coin1LVL && coinAct < coin1LVL+coin2LVL){
                    if(coin==coin1LVL){ //jeśli osiągniemy ilość punktów do przejścia na kolejny poziom to teleportuj bohatera
                        teleport = true;
                        //gameObject.transform.position= new Vector3(28,2,0);
                    }
                    textCoins.text = (coin-coin1LVL-1).ToString() + " / " + coin2LVL;
                }
                if(coinAct >= coin1LVL+coin2LVL && coinAct < coin1LVL+coin2LVL+coin3LVL){
                    if(coinAct==coin1LVL+coin2LVL){
                        gameObject.transform.position= new Vector3(79,10,0);
                    }
                    textCoins.text = (coin-(coin1LVL+coin2LVL)-1).ToString() + " / " + coin3LVL;
                }
                
                    //tworzymy Vector3 z miejscem kolizji
                Vector3 colPosition = collision.transform.position;
                    //Odtwórz dźwięk coinSound w miejscu kolizji
                AudioSource.PlayClipAtPoint(coinSound, colPosition, volume);
                    //Zniszcz obiekt
                Destroy(collision.gameObject);
            }
    
         }



        //////////////////////
        /*{
            if (collision.gameObject.tag == "Coins")
            {
                //powiększ coin o 1
                coin++;
                coinAct = coin;
                //zmien wczesniej wybrany TextMeshPro na Tekst + ilość punktów zamienionych na string        
                textCoins.text = coin.ToString() + " / 10";
                //TO BĘDZIE DO ZMIANY
                if(coin>=10 && coin<36)
                {
                    if(coin==10)
                    gameObject.transform.position= new Vector3(28,2,0);
                textCoins.text = (coin-10).ToString() + " / 26";
                }
                if(coin==36)
                {
                    gameObject.transform.position= new Vector3(79,10,0);
                textCoins.text = (coin-36).ToString() + " / TBC";

                }
                //tworzymy Vector3 z miejscem kolizji
                Vector3 colPosition = collision.transform.position;
                //Odtwórz dźwięk coinSound w miejscu kolizji
                AudioSource.PlayClipAtPoint(coinSound, colPosition, volume);
                //Zniszcz obiekt
                Destroy(collision.gameObject);
            }
    
        }
        */
}
