using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuncExetion : MonoBehaviour
{
    public List<WrappedFunc> Interactions;
    [SerializeField] List<SetDialogue> prebuild;
    void Start()
    {
        if ((Interactions == null || Interactions.Count == 0) &&
            (prebuild == null || prebuild.Count == 0))
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
        if(prebuild != null && prebuild.Count > 0)
        {
            foreach (SetDialogue dialogue in prebuild)
            {
                dialogue.Interacted();
            }
        }
    }
}
[Serializable]
public class SetDialogue
{
    public GameObject obj;
    public string text;
    public void Interacted()
    {
        if(obj == null)
        {
            GameObject.FindObjectOfType<DialogueBox>().SetDialogue(text);
            return;
        }
        InventoryManager invMan = GameObject.FindObjectOfType<InventoryManager>();
        if (invMan == null)
        {
            Debug.LogError("No inventory manager found!");
            return;
        }
        if (!invMan.IsEmpty() && invMan.GetItemInInventory().gameObject == obj)
        {
            GameObject.FindObjectOfType<DialogueBox>().SetDialogue(text);
        }
    }
}
[Serializable]
public class WrappedFunc
{

    public int objectiveNumber = 0;
    public GameObject obj;
    public UnityEvent act;

    public void Interacted()
    {

        bool objectiveGood = true;
        if (ObjectiveScene.Instance != null)
        {
            objectiveGood = (objectiveNumber <= ObjectiveScene.Instance.GetCurrentObjective());
        }


        if(obj == null && objectiveGood)
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

        bool goodItemInInventory = (!invMan.IsEmpty() && invMan.GetItemInInventory().gameObject == obj);
        if (goodItemInInventory && objectiveGood)
        {
            act?.Invoke();
        }
    }
}
