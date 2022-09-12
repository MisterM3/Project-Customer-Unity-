using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{

    public static CamController instance;

    private float zRotation = 0;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("There can only be one CamController, destroying" + gameObject);
            Destroy(gameObject);
        }
        instance = this;
    }

    [SerializeField]Transform camPosition;
    Quaternion playerRotation;
    float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        
        playerRotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camPosition.position;
        yRotation -= Input.GetAxisRaw("Mouse Y");
        yRotation = Mathf.Clamp(yRotation, -90, 90);
        transform.rotation = Quaternion.Euler(yRotation, playerRotation.eulerAngles.y, zRotation);
    }




    public void AddZRotation(float rotation)
    {
        zRotation = rotation;
    }
}
