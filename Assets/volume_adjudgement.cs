using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volume_adjudgement : MonoBehaviour
{

    [SerializeField] UserSettings settings;

    public void Update()
    {
        AudioListener.volume = settings.GetSetting(UserSettings.FloatSettings.sound);
        
    }
}
