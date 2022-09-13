using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInteraction : MonoBehaviour
{
    [SerializeField] Toggle toggle;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] UserSettings.BoolSettings setting;
    [SerializeField] Image imageToMirror;
    UserSettings userSettings;
    bool lastValue;
    // Start is called before the first frame update
    void Start()
    {
        if(text == null)
        {
            Debug.LogError("Text box is not assigned");
            return;
        }
        if(toggle == null)
        {
            Debug.LogError("Toggle not assigned");
            return;
        }
        userSettings = FindObjectOfType<UserSettings>();
        if (userSettings == null)
        {
            Debug.LogError("Could not find User Settings");
            return;
        }
        toggle.isOn = userSettings.GetSetting(setting);

    }

    private void Update()
    {
        if (lastValue == toggle.isOn) return;
        lastValue = toggle.isOn;
        userSettings.UpdateSetting(toggle.isOn, setting);
        MirrorImage();
        text.text = toggle.isOn ? "ON" : "OFF";
    }
    void MirrorImage()
    {
        Vector3 imageScale = imageToMirror.transform.localScale;
        Vector3 mirroredScale = new Vector3(-imageScale.x, imageScale.y, imageScale.z);
        imageToMirror.transform.localScale = mirroredScale;
    }
}
