using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MySceneManager : MonoBehaviour
{
    //public static MySceneManager instance { get; private set; }
    // Start is called before the first frame update

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// Call this method to change the scene
    /// </summary>
    /// <param name="sceneNumber">Scene number you want to change to</param>
    public void ChangeScene(int sceneNumber)
    {
        if (sceneNumber > SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("Invalid scene number");
            return;
        }
        if (SceneManager.GetActiveScene().buildIndex == sceneNumber) return;
        SceneManager.LoadScene(sceneNumber);
    }

    /// <summary>
    /// Call this method to load to the next scene in the buildindex
    /// </summary>
    public void NextScene()
    {
        ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayGoodEnding()
    {
        FindObjectOfType<UserSettings>().UpdateSetting(true, UserSettings.BoolSettings.IsEndingGood);
        ChangeScene(4);
    }
    public void PlayBadEnding()
    {
        FindObjectOfType<UserSettings>().UpdateSetting(false, UserSettings.BoolSettings.IsEndingGood);
        ChangeScene(4);
    }
}
