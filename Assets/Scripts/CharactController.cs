using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharactController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]int speed;
    [SerializeField] int interactionDistance;

    [SerializeField] LayerMask objectLayer;

    float xInput,yInput;
    float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
<<<<<<< HEAD
        rb = GetComponent<Rigidbody>();

=======
        rb = GetComponent<Rigidbody>();

>>>>>>> 5cbe09c65e7ac7c3a553a5a3749b9d10754f58df
     //   objectLayer = LayerMask.GetMask("Interactable");
    }
    private void FixedUpdate()
    {
        Vector3 velocity = (transform.forward * yInput) + (transform.right * xInput);
        velocity = velocity.normalized * Time.deltaTime * speed;
        rb.velocity = velocity + new Vector3(0,rb.velocity.y,0);
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        CheckInteraction();
        transform.rotation = Quaternion.Euler(new Vector3(0, xRotation));
    }
    void CheckInteraction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = MouseWorld.Instance.GetObjectInFront(interactionDistance, objectLayer);
            if (hit.transform != null)
            {
                Debug.Log("Hit something");
                InteractableObject interactableObject = hit.transform.gameObject.GetComponent<InteractableObject>();
                FindObjectOfType<DialogueBox>().SetDialogue(interactableObject.GetTextToShow());
            }
            Debug.Log("end");
        }
    }
    void GetInput()
    {
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");

        xRotation += Input.GetAxisRaw("Mouse X");
    }
}
