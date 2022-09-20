using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTriggers : MonoBehaviour
{

    private bool once = true;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AAAAAAAAAAAAAAA");
        ObjectiveScene.Instance.IsTriggerTheObjective(this.GetComponent<Collider>());

        if (once && TryGetComponent<FuncExetion>(out FuncExetion funcEx))
        {
            funcEx.Interact();
            once = false;
        }
        
    }
}
