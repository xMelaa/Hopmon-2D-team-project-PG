using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class CoinPick : MonoBehaviour
{
    public bool teleport = false;    
        //Aktualna ilość punktów
    private int coin = 0;
    private int coinLVL = 0;
    public int lvlNumber = 0;
        //Pobieramy muzykę do coinSound
    public AudioClip coinSound;
        //Głośność muzyki
    public float volume;
        //Pobieramy TextMeshPro do textCoins
    public TextMeshProUGUI textCoins;
        //W trakcie kolizji, algorytm sam wylicza ile jest i ile powinno być punktów, nie trzeba zmieniać

    void Start()
    {
        lvlNumber = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (lvlNumber)
                {
                    case 1:
                        coinLVL = 10;
                        break;
                    case 2:
                        coinLVL = 12;
                        break;
                    case 3:
                        coinLVL = 56;
                        break;
                    case 4:
                        coinLVL = 24;
                        break;
                    case 5:
                        coinLVL = 42;
                        break;
                    case 6:
                        coinLVL = 62;
                        break;
                    case 7:
                        coinLVL = 24;
                        break;
                    case 8:
                        coinLVL = 44;
                        break;
                    case 9:
                        coinLVL = 64;
                        break;
                    default:
                        break;
                }

            if (collision.gameObject.tag == "Coins")
            {
                    //powiększ coin o 1
                coin++;
                //zmien wczesniej wybrany TextMeshPro na Tekst + ilość punktów zamienionych na string
                if(coin==coinLVL){ //jeśli osiągniemy ilość punktów do przejścia na kolejny poziom to odblokuj teleport /teleportuj bohatera/
                    teleport = true;
                    //gameObject.transform.position= new Vector3(28,2,0);
                }
                textCoins.text = coin.ToString() + " / " + coinLVL;
                   
                /*if(lvlNumber = 2){
                    if(coinAct==coinLVL){ //jeśli osiągniemy ilość punktów do przejścia na kolejny poziom to odblokuj teleport /teleportuj bohatera/
                        teleport = true;
                        //gameObject.transform.position= new Vector3(28,2,0);
                    }
                    textCoins.text = coin.ToString() + " / " + coin2LVL;
                }*/
                
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
