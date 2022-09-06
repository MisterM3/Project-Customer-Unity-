using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField]Transform camPosition;
    [SerializeField]Transform playerRotation;
    float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        playerRotation = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camPosition.position;
        yRotation -= Input.GetAxisRaw("Mouse Y");
        yRotation = Mathf.Clamp(yRotation, -90, 90);
        transform.rotation = Quaternion.Euler(yRotation, playerRotation.rotation.eulerAngles.y, 0);
    }
}
