using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSettings : MonoBehaviour
{
    static UserSettings userSettings;
    public enum FloatSettings { sound = 0, brightness = 1, sensetivity = 2 };
    public enum BoolSettings { FullScreen, Cursor, IsEndingGood };

    float sound = .3f, brightness = .2f, sensetivity = .5f;
    bool fullScreen = true, cursor = true;
    bool isGoodEnding;

    Dictionary<FloatSettings, float> floatSettingsValues;
    Dictionary<BoolSettings, bool> boolSettingsValues;

    private void Start()
    {
        if (userSettings != null && userSettings != this)
        {
            Destroy(this.gameObject);
        }
        if (userSettings == null)
        {
            userSettings = this;
            CreateBoolDictionary();
            CreateFloatDictionary();

            DontDestroyOnLoad(this.gameObject);
        }
        if (floatSettingsValues == null) CreateFloatDictionary();
        if (boolSettingsValues== null) CreateBoolDictionary();
    }
    void CreateFloatDictionary()
    {
        floatSettingsValues = new Dictionary<FloatSettings, float>();

        floatSettingsValues.Add(FloatSettings.sound, sound);
        floatSettingsValues.Add(FloatSettings.brightness, brightness);
        floatSettingsValues.Add(FloatSettings.sensetivity, sensetivity);
    }
    void CreateBoolDictionary()
    {
        boolSettingsValues = new Dictionary<BoolSettings, bool>();
        boolSettingsValues.Add(BoolSettings.FullScreen, fullScreen);
        boolSettingsValues.Add(BoolSettings.Cursor, cursor);
        boolSettingsValues.Add(BoolSettings.IsEndingGood, isGoodEnding);

    }

    public void UpdateSetting(float value, FloatSettings setting) => floatSettingsValues[setting] = value;
    public void UpdateSetting(bool value, BoolSettings setting)
    {
        boolSettingsValues[setting] = value;
        switch (setting)
        {
            case BoolSettings.FullScreen:
                Screen.fullScreen = value;
                break;
        }
    }

    public float GetSetting(FloatSettings settingToGet)
    {
        if (floatSettingsValues == null) Debug.Log("NOT THERE");
    return floatSettingsValues[settingToGet];
    }
    public bool GetSetting(BoolSettings settingToGet) => boolSettingsValues[settingToGet];
}
