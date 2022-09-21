using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftCameraIntoCar : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform cameraInCar;
    [SerializeField] private Transform cameraOutsideCar;
    [SerializeField] private AnimationCurve xPosition;
    private bool Active = false;
    float timer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        cam.transform.position = cameraOutsideCar.position; 
    }

    // Update is called once per frame
    void Update()
    {
    //    if (Input.GetKeyDown(KeyCode.T)) 
       

        
    }


    public void HopInCar()
    {
        Active = true;
        HopToPos(cam.transform.position, cameraInCar.position);
    }

    public void HopOutCar()
    {
        HopToPos(cameraInCar.position, cameraOutsideCar.position);
    }

    private void HopToPos(Vector3 moveFromPos, Vector3 moveToPos)
    {
        if (!Active) return;


        if (timer < 1)
        {
            float yPos = Mathf.Lerp(cam.transform.position.y, moveToPos.y, Time.deltaTime);
            float xValue = xPosition.Evaluate(timer);
            float xPos = moveFromPos.x * (1 - xValue) + moveToPos.x * (xValue);
            float zPos = moveFromPos.z * (1 - xValue) + moveToPos.z * (xValue);

            cam.transform.position = new Vector3(xPos, yPos, zPos);
            timer += Time.deltaTime;
        }
        else Active = false;
    }
}
