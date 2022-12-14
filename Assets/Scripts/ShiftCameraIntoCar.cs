using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftCameraIntoCar : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform cameraInCar;
    [SerializeField] private Transform cameraOutsideCar;
    [SerializeField] private AnimationCurve xPosition;
    [SerializeField] private CharactController controller;
    private bool Active = false;
    static private bool inCar = true;
    float timer = 0;


    [SerializeField] bool startPos = false;
    Vector3 moveTo;
    Vector3 moveFrom;
    
    // Start is called before the first frame update
    void Start()
    {
        if (startPos)
        {
            controller = FindObjectOfType<CharactController>();
            player.transform.position = cameraInCar.position;
            controller.SetIsInCar(true);
            player.TryGetComponent<Rigidbody>(out Rigidbody rb);
            rb.useGravity = false;
            player.TryGetComponent<Collider>(out Collider col);
            col.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
 

        if (!Active) return;

        HopToPos(moveFrom, moveTo);
          
    }


    public void HopInCar()
    {
        if (inCar) return;
        Active = true;
        inCar = true;
        controller.SetIsInCar(true);
        player.TryGetComponent<Rigidbody>(out Rigidbody rb);
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        player.TryGetComponent<Collider>(out Collider col);
        col.enabled = false;
        moveFrom = player.transform.position;
        moveTo = cameraInCar.position;
    }

    public void HopOutCar()
    {
        if (!inCar) return;
        Active = true;
        inCar = false;
        moveFrom = cameraInCar.position;
        moveTo = cameraOutsideCar.position;
    }

    private void HopToPos(Vector3 moveFromPos, Vector3 moveToPos)
    {
        if (!Active) return;


        if (timer < 1)
        {
            float yPos = Mathf.Lerp(player.transform.position.y, moveToPos.y, Time.deltaTime);
            float xValue = xPosition.Evaluate(timer);
            float xPos = moveFromPos.x * (1 - xValue) + moveToPos.x * (xValue);
            float zPos = moveFromPos.z * (1 - xValue) + moveToPos.z * (xValue);

            player.transform.position = new Vector3(xPos, yPos, zPos);
            timer += Time.deltaTime;
        }
        else
        {
            Active = false;
            timer = 0;
            if (!inCar)
            {
                controller.SetIsInCar(false);
                player.TryGetComponent<Rigidbody>(out Rigidbody rb);
                rb.useGravity = true;
                player.TryGetComponent<Collider>(out Collider col);
                col.enabled = true;
            }

           
        }


    }
}
