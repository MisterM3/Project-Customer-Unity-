using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickable : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Release()
    {
        rb.useGravity = true;
    }
    public void PickUp()
    {
        rb.useGravity = false;
    }
    public void MoveToPos(Vector3 vec)
    {
        Vector3 velocity = vec - transform.position;
        rb.velocity = velocity * 4;
    }
}
