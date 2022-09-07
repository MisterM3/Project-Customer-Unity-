using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingTool : MonoBehaviour
{

    [SerializeField] LayerMask layerMask;

    public void Update()
    {
        SelectObject();
    }
    public void SelectObject()
    {

        Ray lookingAt = MouseWorld.Instance.RayAtScreenPosition();

        float distanceRay = 5f;
        Debug.DrawRay(lookingAt.origin, lookingAt.direction * distanceRay, Color.yellow);


        if (Physics.Raycast(lookingAt, out RaycastHit info, distanceRay, layerMask))
        {
            info.collider.gameObject.GetComponentInParent<IInteract>().Activate();
        }
    }
}
