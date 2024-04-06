using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip buttonsSound, cancelSound, quitSound, hoverSound;
    
    public void Buttons()
    {
        src.clip = buttonsSound;
        src.Play();
    }

    public void CancelBSound()
    {
        src.clip = cancelSound;
        src.Play();
    }

    public void QuitBSound()
    {
        src.clip = quitSound;
        src.Play();
    }
}
