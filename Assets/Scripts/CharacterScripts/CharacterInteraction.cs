using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] int interactionDistance, pickupDistance;
    [SerializeField] LayerMask objectLayer;
    Transform cameraTransform;
    RaycastHit frontHit;

    #region Holding object variables
    [SerializeField, Tooltip("Max distance to hold the object")] float releaseDistance;
    bool isHoldingObject;
    Pickable holdedObject;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        CheckPickedObjectPosition();
    }
    private void LateUpdate()
    {

       if (frontHit.transform == null) return;

        if (frontHit.transform.TryGetComponent(out OutlineObjects outline))
        {
            outline.ActivateOutline();
            Debug.Log("help");
        }
    }
    private void CheckPickedObjectPosition()
    {
        if (holdedObject == null) return;

        Vector3 desiredPos = cameraTransform.position + cameraTransform.forward * 2;
        Vector3 distanceFromPlayer = desiredPos - holdedObject.transform.position;

        holdedObject.MoveToPos(desiredPos);
        if (distanceFromPlayer.magnitude > releaseDistance) ReleaseObject();
    }
    void CheckInteraction()
    {
        frontHit = MouseWorld.Instance.GetObjectInFront(pickupDistance,objectLayer);
        //if (frontHit.transform == null) return;
        

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHoldingObject)
            {
                ReleaseObject();
            }
            else
            {
                if (frontHit.transform == null) return;
                if (IsPickable(frontHit.transform.gameObject, out Pickable pick))
                {
                    holdedObject = pick;
                    isHoldingObject = true;
                    Debug.Log("Picked up");
                }
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit hit = MouseWorld.Instance.GetObjectInFront(interactionDistance, objectLayer);
            if (frontHit.transform != null)
            {
                if (frontHit.transform.TryGetComponent(out FuncExetion func))
                {
                    Debug.Log("boom!");
                    func.Interact();
                }
            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            if(InventoryManager.Instance == null)
            {
                Debug.LogError("No inventory in the scene!");
                return;
            }
            if (!InventoryManager.Instance.IsEmpty())
            {
                InventoryManager.Instance.RemoveItemFromInventory();
                return;
            }

            //RaycastHit hit = MouseWorld.Instance.GetObjectInFront(interactionDistance, objectLayer);
            if (frontHit.transform != null)
            {
                Debug.Log("char");
                InteractableObject interactableObject = frontHit.transform.gameObject.GetComponent<InteractableObject>();
                interactableObject.PickUp();

            }

        }

    }
    void ReleaseObject()
    {
        holdedObject = null;
        isHoldingObject = false;
        Debug.Log("Released");
    }
    bool IsPickable(GameObject obj) => obj.GetComponent<Pickable>() != null;
    bool IsPickable(GameObject obj, out Pickable pickable)
    {
        pickable = obj.GetComponent<Pickable>();
        if (pickable != null)
        {
            return true;
        }
        return false;
    }
}
