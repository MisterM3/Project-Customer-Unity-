using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{

    [SerializeField] AudioSource hoverSound;
    [SerializeField] AudioSource clickSound;

    public void PlayHover()
    {
        if (!hoverSound.isPlaying) hoverSound.Play();
    }
    public void PlayClick()
    {
        if (!clickSound.isPlaying) clickSound.Play();
    }
}
