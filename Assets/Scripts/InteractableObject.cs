using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour, IInteract
{
    public event EventHandler onObjectSelect;
    public event EventHandler onObjectDeSelect;
    [SerializeField, TextArea] string TextToShow;

    public bool IsActive = false;

    public void Activate()
    {
        if (!IsActive)
        {
            Debug.Log("Selected!");
            IsActive = true;
            onObjectSelect?.Invoke(this, EventArgs.Empty);
        }
    }

    public void PickUp()
    {
        InventoryManager.Instance.AddItemToInventory(this.transform);

        
    }

    void Update()
    {

        if (!IsActive) return;



        Ray lookingAt = MouseWorld.Instance.RayAtScreenPosition();
        bool isObjectInRay = MouseWorld.Instance.IsObjectInRay(lookingAt, 5f, this.transform);
        if (!isObjectInRay)
        {
            IsActive = false;
            Debug.Log("Not selected still");
            onObjectDeSelect?.Invoke(this, EventArgs.Empty);
        }
    }

    public string GetTextToShow()
    {
        return TextToShow;
    }


}
