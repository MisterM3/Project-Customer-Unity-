using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncTrigger : MonoBehaviour
{
    private bool firstTrigger = true;
    private void OnTriggerEnter(Collider other)
    {
        if (firstTrigger && other.tag == "Player" && TryGetComponent<FuncExetion>(out FuncExetion func))
        {
            Debug.Log("works");
            func.Interact();
            firstTrigger = false;
        }
    }
}
