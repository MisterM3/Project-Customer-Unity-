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
        velocity = velocity.normalized * Time.deltaTime * speed;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit = MouseWorld.Instance.GetObjectInFront(pickupDistance);

            Pickable pick;
            if (isHoldingObject)
            {
                ReleaseObject();
            }
            else
            {
                if (hit.transform == null) return;
                if (isPickable(hit.transform.gameObject, out pick))
                {
                    pick.PickUp();
                    holdedObject = pick;
                    isHoldingObject = true;
                }
            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = MouseWorld.Instance.GetObjectInFront(interactionDistance, objectLayer);
            if (hit.transform != null)
            {
                InteractableObject interactableObject = hit.transform.gameObject.GetComponent<InteractableObject>();
                FindObjectOfType<DialogueBox>().SetDialogue(interactableObject.GetTextToShow());
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
        holdedObject.Release();
        holdedObject = null;
        isHoldingObject = false;
    }
    bool isPickable(GameObject obj) => obj.GetComponent<Pickable>() != null;
    bool isPickable(GameObject obj, out Pickable pickable)
    {
        pickable = obj.GetComponent<Pickable>();
        if (pickable != null)
        {
            return true;
        }
        return false;
    }
}
