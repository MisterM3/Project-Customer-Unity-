using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{

    public static MouseWorld Instance { get; private set; }

    private Camera _camera;

    [SerializeField] private LayerMask layerMask;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one MouseWorld detected, destroying:" + gameObject);
            Destroy(gameObject);
        }

        _camera = Camera.main;
        Instance = this;
    }


    public Ray RayAtScreenPosition()
    {
        Debug.Log("sTART RAY");
        Ray ray = new Ray(_camera.transform.position,_camera.transform.forward);
        return ray;
    }

    public RaycastHit GetObjectInFront(float distance,LayerMask layerMask)
    {
        RaycastHit hit;
        Physics.Raycast(RayAtScreenPosition(),out hit,distance,layerMask);
        Debug.Log(hit);
        return hit;
    }

    public bool IsObjectInRay(Ray ray, float distance, Transform gameObject)
    {
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.yellow);


        if (Physics.Raycast(ray, out RaycastHit info, distance, layerMask))
        {
            Transform objectInRay = info.collider.transform;
            return (gameObject == objectInRay);
        } else return false;

    }




}
