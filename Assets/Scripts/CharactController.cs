using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharactController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] int speed;
    [SerializeField] int interactionDistance, pickupDistance;
    Transform cameraTransform;

    [SerializeField] LayerMask objectLayer;
    RaycastHit frontHit;

    float xInput, yInput;
    float xRotation;

    [Header("Item")]
    #region Holding object variables
    [SerializeField,Tooltip("Max distance to hold the object")] float releaseDistance;
    bool isHoldingObject;
    Pickable holdedObject;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 velocity = (transform.forward * yInput) + (transform.right * xInput);
        velocity = speed * Time.deltaTime * velocity.normalized;
        rb.velocity = velocity + new Vector3(0, rb.velocity.y, 0);
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        CheckInteraction();
        CheckPickedObjectPosition();
        transform.rotation = Quaternion.Euler(new Vector3(0, xRotation));
    }
    private void LateUpdate()
    {
        if (frontHit.transform == null) return;
        if (frontHit.transform.TryGetComponent(out OutlineObjects outline)) outline.ActivateOutline();
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
            frontHit = MouseWorld.Instance.GetObjectInFront(pickupDistance);
        if (frontHit.transform == null) return;
        
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
                //InteractableObject interactableObject = hit.transform.gameObject.GetComponent<InteractableObject>();
                //FindObjectOfType<DialogueBox>().SetDialogue(interactableObject.GetTextToShow());

                if (frontHit.transform.TryGetComponent(out FuncExetion func))
                {
                    Debug.Log("boom!");
                    func.Interact();
                }
            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            if (!InventoryManager.Instance.GetIsEmpty())
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
    void GetInput()
    {
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");

        xRotation += Input.GetAxisRaw("Mouse X");
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
