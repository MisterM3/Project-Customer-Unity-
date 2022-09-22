using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{

    [SerializeField] private Animation clip;
    

    public void StartClip()
    {
        clip.Play();
    }
}
