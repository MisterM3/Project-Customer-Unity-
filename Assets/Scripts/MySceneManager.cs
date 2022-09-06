using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MySceneManager : MonoBehaviour
{
    static MySceneManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }
    /// <summary>
    /// Call this method to change the scene
    /// </summary>
    /// <param name="sceneNumber">Scene number you want to change to</param>
    public void ChangeScene(int sceneNumber)
    {
        if(sceneNumber > SceneManager.sceneCount)
        {
            Debug.LogError("Invalid scene number");
            return;
        }
        if (SceneManager.GetActiveScene().buildIndex == sceneNumber) return;
        SceneManager.LoadScene(sceneNumber);
    }
}
