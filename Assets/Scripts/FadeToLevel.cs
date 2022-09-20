using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToLevel : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Action onAnimationComplete;


    public void FadeOutToLevel(Action finishAnim)
    {
        onAnimationComplete = finishAnim;
        animator.SetTrigger("FadeOut");
    }

    public void OnAnimationComplete()
    {
        onAnimationComplete();
    }

}
