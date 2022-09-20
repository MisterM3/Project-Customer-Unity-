
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToLevel : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private int loadlevel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) FadeOutToNextLevel();
    }
    public void FadeOutToNextLevel()
    {
        FadeOutToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void FadeOutToLevel(int index)
    {
        loadlevel = index;
        animator.SetTrigger("FadeOut");
    }

    public void OnAnimationComplete()
    {
        MySceneManager.instance.ChangeScene(loadlevel);
    }
}
