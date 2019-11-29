using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audios;
    
    public void SoundButton(Toggle SoundToggle)
    {
        if (SoundToggle.isOn == true)
        {
            for (int i = 0; i < audios.Length; i++)
            {
                audios[i].mute = true;
            }
        }
        if (SoundToggle.isOn == false)
        {
            for (int i = 0; i < audios.Length; i++)
            {
                audios[i].mute = false;
            }
        }
    }
}
