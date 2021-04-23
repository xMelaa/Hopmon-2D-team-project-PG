using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinPick : MonoBehaviour
{
    //Aktualna ilość punktów
    private int coin = 0;
    //Pobieramy muzykę do coinSound
    public AudioClip coinSound;
    //Głośność muzyki
    public float volume;
    //Pobieramy TextMeshPro do textCoins
    public TextMeshProUGUI textCoins;
    //W trakcie kolizji
         private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            //powiększ coin o 1
            coin++;
            //zmien wczesniej wybrany TextMeshPro na Tekst + ilość punktów zamienionych na string        
            textCoins.text = "Punkty: " + coin.ToString() + " / 10";
            //TO BĘDZIE DO ZMIANY
            if(coin>=10 && coin<36)
            {
                if(coin==10)
            gameObject.transform.position= new Vector3(28,2,0);
               textCoins.text = "Punkty: " + (coin-10).ToString() + " / 26";
            }
            if(coin==36)
            {
                gameObject.transform.position= new Vector3(28,2,0);
               textCoins.text = "Punkty: " + (coin-36).ToString() + " / inf";

            }
            //Odtwórz dźwięk coinSound w miejscu 0,0,0 z głośnościa volume
            AudioSource.PlayClipAtPoint(coinSound, Vector3.zero, volume);
            //Zniszcz obiekt
            Destroy(collision.gameObject);
        }
 
    }
}
