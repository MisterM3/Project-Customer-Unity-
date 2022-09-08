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
        
        float realMass = rb.mass*transform.position.y;
        Vector3 verticalDrag = rb.mass * Vector3.down;
        velocity.y = velocity.y < 0 ? rb.velocity.y + velocity.y : velocity.y + verticalDrag.y;
        velocity = new Vector3(velocity.x * 4, velocity.y, velocity.z * 4);

        rb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);
    }
}
