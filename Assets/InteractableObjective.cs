using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjective : MonoBehaviour
{


    public void Interacted()
    {
        Debug.Log("next scene");
        MySceneManager.instance.NextScene();
    }
}
