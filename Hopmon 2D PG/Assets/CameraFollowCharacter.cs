using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour
{
    public GameObject player; // referencja do naszego bohatera gry

    private Vector3 offset; // odleglosc przesunieca pomiedzy bohaterem i kamera

    // wywolywana na samym poczatku
    private void Start()
    {
        //wyliczenie offsetu jako roznicy pozycji kamery i bohatera
        offset = transform.position - player.transform.position;
    }

    // LateUpdate jest wywolywany po aktualizacji kazdej klatki
    private void LateUpdate()
    {
        // ustawia pozycje kamery na taką jak gracza, ale dodaje wyliczone przesuniecie
        transform.position = player.transform.position + offset;
    }
}