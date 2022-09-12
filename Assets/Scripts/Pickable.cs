using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickable : MonoBehaviour
{
    Rigidbody rb;
    enum Weight { Light, Medium, Heavy };
    [SerializeField] Weight weight;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void MoveToPos(Vector3 vec)
    {
        Vector3 verticalDrag = .5f * Vector3.down;
        Vector3 velocity = vec - transform.position;
        switch (weight)
        {
            case Weight.Light:
                rb.velocity = velocity*4;
                break;
            case Weight.Medium:
                velocity.y = velocity.y < 0 ? rb.velocity.y + velocity.y : velocity.y + verticalDrag.y;
                rb.velocity = new Vector3(velocity.x * 2, velocity.y, velocity.z * 2);
                break;
            case Weight.Heavy:
                rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
                break;
        }
    }
}
