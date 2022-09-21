using UnityEngine;
using UnityEngine.Video;

public class CutsceneScript : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] AudioSource audioSource;
    [SerializeField] int nextScene;

    bool hasStarted;
    private void Awake()
    {
        videoPlayer.Play();
    }
    void Update()
    {
        if (videoPlayer.isPlaying && !hasStarted)
        {
            hasStarted = true;
        }
        
        if (!videoPlayer.isPlaying && hasStarted)
        {
            FindObjectOfType<MySceneManager>().ChangeScene(nextScene);
        }
    }
}
