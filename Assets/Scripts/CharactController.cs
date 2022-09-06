using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharactController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Transform cam;

    [SerializeField]int speed;

    float xInput,yInput;
    float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
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
        transform.rotation = Quaternion.Euler(new Vector3(0, xRotation));
        
        if (Input.GetKeyDown(KeyCode.F)) Debug.Log(xRotation);
    }
    void GetInput()
    {
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");

        xRotation += Input.GetAxisRaw("Mouse X");


    }
}
