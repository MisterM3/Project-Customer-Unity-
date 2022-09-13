using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderInteraction : MonoBehaviour
{
    [SerializeField]Slider slider;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] UserSettings.Settings settingToUpdate;
    UserSettings userSetting;
    float lastValue;
    private void Start()
    {
        if(text == null)
        {
            Debug.LogError("No text assgined");
            return;
        }
        if(slider == null)
        {
            Debug.LogError("No slider assigned");
            return;
        }
        userSetting = FindObjectOfType<UserSettings>();
        if (userSetting == null) Debug.LogError("No UserSettings found");
        slider.value = userSetting.GetSetting(settingToUpdate);
    }

    private void Update()
    {
        if (lastValue == slider.value) return;
        text.text = Mathf.Round(slider.value * 100) + "%";
        userSetting.UpdateSetting(slider.value,settingToUpdate);
        lastValue = slider.value;
    }
    

}
