using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkCameraMovement : MonoBehaviour
{

    [SerializeField] AnimationCurve drunkMove;
    [SerializeField] float movementIntensity = 5f;
    [SerializeField] float moveSpeed = 10f;

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime / moveSpeed;
        float CameraRotZ = drunkMove.Evaluate(timer) * movementIntensity;

       CamController.instance.AddZRotation(CameraRotZ);
    }
}
