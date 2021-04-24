using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    public void SetVolume(float volume){ //ustawiamy głośność za pomocą mixera
        audiomixer.SetFloat("volume",volume);
    }

    public void SetFullscreen (bool isFullscreen){ //ustawianie wielkości okna
        Screen.fullScreen = isFullscreen;
    }
}
