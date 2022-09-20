using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour
{
    [SerializeField] AudioSource enableSetting;
    [SerializeField] AudioSource diableSetting;
    [SerializeField] Toggle toggle;


    public void PlaySoundAtToggle()
    {
        if (toggle.isOn)
        {
            diableSetting.Play();
        } else
        {
            enableSetting.Play();
        }
    }
}
