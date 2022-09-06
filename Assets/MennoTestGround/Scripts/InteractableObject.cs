using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteract
{
    [SerializeField] private LayerMask layerMask;
    public bool IsActive = false;
    public void Activate()
    {
        if (!IsActive)
        {
            Debug.Log("Selected!");
            IsActive = true;
        }
    }

    public void Update()
    {

        if (!IsActive) return;


        if (Input.GetMouseButtonDown(0))
        {
            Dialogue();
        }



        Ray lookingAt = MouseWorld.Instance.RayAtScreenPosition();
        bool isObjectInRay = MouseWorld.Instance.IsObjectInRay(lookingAt, 5f, this.transform);
        if (!isObjectInRay)
        {
            IsActive = false;
            Debug.Log("Not selected still");
        }

        
    }


    private void Dialogue()
    {
        Debug.Log("Dialogue");
    }
}
