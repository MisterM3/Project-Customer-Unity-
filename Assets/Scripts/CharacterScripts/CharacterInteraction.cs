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
    [SerializeField] float holdDistance;
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

        Vector3 desiredPos = cameraTransform.position + cameraTransform.forward * holdDistance;
        Vector3 distanceFromPlayer = desiredPos - holdedObject.transform.position;

        holdedObject.MoveToPos(desiredPos);
        if (distanceFromPlayer.magnitude > releaseDistance) ReleaseObject();
    }
    void CheckInteraction()
    {
        frontHit = MouseWorld.Instance.GetObjectInFront(objectLayer);

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
                    float dist = GetDistOnPlane(cameraTransform.position,pick.transform.position);
                    if (dist > pickupDistance) return;
                    holdedObject = pick;
                    isHoldingObject = true;
                    Debug.Log("Picked up");
                }
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit hit = MouseWorld.Instance.GetObjectInFront(interactionDistance, objectLayer);
            if (frontHit.transform != null && GetDistOnPlane(cameraTransform.position,frontHit.transform.position) <= interactionDistance)
            {
                if (frontHit.transform.TryGetComponent(out FuncExetion func))
                {
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
    float GetDistOnPlane(Vector3 pos1, Vector3 pos2)
    {
        Vector2 point1 = new Vector2(pos1.x, pos1.z);
        Vector2 point2 = new Vector2(pos2.x, pos2.z);
        return Vector2.Distance(point1, point2);
    }

}
