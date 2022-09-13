using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSettings : MonoBehaviour
{
    static UserSettings userSettings;
    public enum Settings { sound = 0, brightness = 1, sensetivity = 2 };
    float sound = .2f, brightness = .2f, sensetivity = .2f;
    Dictionary<Settings, float> settingsValues;

    private void Start()
    {
        if (userSettings != null && userSettings != this)
        {
            Destroy(this.gameObject);
        }
        if (userSettings == null)
        {
            userSettings = this;
            settingsValues = new Dictionary<Settings, float>();

            settingsValues.Add(Settings.sound, sound);
            settingsValues.Add(Settings.brightness, brightness);
            settingsValues.Add(Settings.sensetivity, sensetivity);

            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void UpdateSetting(float value, Settings setting)
    {
        settingsValues[setting] = value;
    }
    public void UpdateSetting(float value, int settingToUpdate)
    {
        settingsValues[(Settings)settingToUpdate] = value;
    }
    public float GetSetting(Settings settingToGet) => settingsValues[settingToGet];
}
