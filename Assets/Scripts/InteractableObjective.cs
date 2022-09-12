using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjective : MonoBehaviour
{
    //private Collider col;

    public void Start()
    {
     //   col = this.GetComponent<Collider>();
    }

    public void Interacted()
    {
        Debug.Log("inte");
        ObjectiveScene.Instance.IsInteractTheObjective(this);
    }
}
