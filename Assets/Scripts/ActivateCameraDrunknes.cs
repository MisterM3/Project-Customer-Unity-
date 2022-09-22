using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCameraDrunknes : MonoBehaviour
{
    [SerializeField] DrunkCameraMovement dcm;

    private void OnCollisionEnter(Collision collision)
    {
        dcm.enabled = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        dcm.enabled = false;
        CamController.instance.AddZRotation(0);
    }
}
