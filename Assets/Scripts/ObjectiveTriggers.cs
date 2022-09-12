using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTriggers : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AAAAAAAAAAAAAAA");
        ObjectiveScene.Instance.IsTriggerTheObjective(other);
    }
}
