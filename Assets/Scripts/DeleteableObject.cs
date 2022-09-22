using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteableObject : MonoBehaviour
{
    public void Delete()
    {
        Destroy(gameObject);
    }
}
