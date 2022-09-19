using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreditsScript : MonoBehaviour
{
    [SerializeField] bool execute;
    [SerializeField]UnityEvent toExecute;

    // Update is called once per frame
    void Update()
    {
        if (execute)
        {
            toExecute?.Invoke();
            execute = false;
        }
    }
}
