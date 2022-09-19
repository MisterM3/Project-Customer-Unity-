using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationScript : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] string animationName;
    [SerializeField]float maxTreshold = .5f;
    float treshold;


    public void PlayAnimation()
    {
        if(treshold < Time.time)
        {
            anim.Play(animationName, 0, 0f);
            treshold = Time.time + maxTreshold;
        }
    }

    private void OnMouseEnter()
    {
        PlayAnimation();
    }

    [ContextMenu("FindAnimation")]
    void FindAnimator()
    {
        anim = GetComponent<Animator>();
        if (GetComponent<EventTrigger>() == null)
        {
            gameObject.AddComponent<EventTrigger>();
        }
    }
}