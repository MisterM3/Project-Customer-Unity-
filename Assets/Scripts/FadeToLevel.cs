using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToLevel : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Action onAnimationComplete;

    [SerializeField] MySceneManager sceneManger;
    private void Start()
    {
       // TryGetComponent<MySceneManager>(out MySceneManager sceneManger);
        //Debug.Log(sceneManger);
    }

    public void SetAction(Action action)
    {
        Debug.Log("help");
    }

    public void FadeToGoodEnding()
    {
        onAnimationComplete = sceneManger.PlayGoodEnding;
        animator.SetTrigger("FadeOut");
    }
    public void FadeToBadEnding()
    {
        onAnimationComplete = sceneManger.PlayBadEnding;
        animator.SetTrigger("FadeOut");
    }

    public void FadeOutToNextLevel()
    {
        onAnimationComplete = sceneManger.NextScene;
        animator.SetTrigger("FadeOut");
    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnAnimationComplete()
    {
        onAnimationComplete();
    }

}
