using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteract
{

    public event EventHandler onObjectSelect;
    public event EventHandler onObjectDeSelect;
    public bool IsActive = false;

    private bool hasDialogue = false;
    private bool hasInteract = false;
    private bool hasPickup = false;

    private DialogueAction dialogue;


    List<BaseAction> actions = new List<BaseAction>();

    public void Awake()
    {
        foreach(BaseAction action in GetComponents<BaseAction>())
        {
            switch(action){
                case DialogueAction:
                    hasDialogue = true;
                    dialogue = action as DialogueAction;
                    break;

            }
            
        }

    }
    public void Activate()
    {
        if (!IsActive)
        {
            Debug.Log("Selected!");
            IsActive = true;
            onObjectSelect?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Update()
    {

        if (!IsActive) return;


        if (hasDialogue && Input.GetMouseButtonDown(0))
        {
            dialogue.Action();
        }
        if (Input.GetMouseButtonDown(1))
        {
            AddingToInventory();
        }



        Ray lookingAt = MouseWorld.Instance.RayAtScreenPosition();
        bool isObjectInRay = MouseWorld.Instance.IsObjectInRay(lookingAt, 5f, this.transform);
        if (!isObjectInRay)
        {
            IsActive = false;
            Debug.Log("Not selected still");
            onObjectDeSelect?.Invoke(this, EventArgs.Empty);
        }

        
    }


    private void Dialogue()
    {
        DialogueBox.Instance.SetDialogue("Dialogue time!");
    }

    private void AddingToInventory()
    {
        Debug.Log("Added to Inventory");
    }
}
