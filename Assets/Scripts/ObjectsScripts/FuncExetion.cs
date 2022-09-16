using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuncExetion : MonoBehaviour
{
    public List<WrappedFunc> Interactions;
    void Start()
    {
        if (Interactions == null || Interactions.Count == 0)
        {
            Debug.LogError("No interactions assigned");
            return;
        }
    }

    public void Interact()
    {
        foreach(WrappedFunc func in Interactions)
        {
            func.Interacted();
        }
    }
}
[Serializable]
public class WrappedFunc
{
    public GameObject obj;
    public UnityEvent act;

    public void Interacted()
    {
        if(obj == null)
        {
            act?.Invoke();
            return;
        }

        InventoryManager invMan = GameObject.FindObjectOfType<InventoryManager>();
        if(invMan == null)
        {
            Debug.LogError("No inventory manager found!");
            return;
        }
        if(!invMan.IsEmpty() && invMan.GetItemInInventory().gameObject == obj)
        {
            act?.Invoke();
        }
    }
}
