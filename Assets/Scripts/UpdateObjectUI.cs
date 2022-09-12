using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateObjectUI : MonoBehaviour
{
    [SerializeField] private GameObject uicanvas;
    [SerializeField] private IInteract interactableObject;


    private void Start()
    {
        interactableObject = GetComponentInParent<IInteract>();
        interactableObject.onObjectSelect += InteractableObject_onObjectSelect;
        interactableObject.onObjectDeSelect += InteractableObject_onObjectDeSelect;
    }

    private void InteractableObject_onObjectDeSelect(object sender, EventArgs e)
    {
        DeActivateUI();
    }

    private void InteractableObject_onObjectSelect(object sender, EventArgs e)
    {
        ActivateUI();
    }


    private void ActivateUI()
    {
        uicanvas.SetActive(true);
    }

    private void DeActivateUI()
    {
        uicanvas.SetActive(false);
    }
}
