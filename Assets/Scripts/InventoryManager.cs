using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [SerializeField] Transform player;
    [SerializeField] Transform inventoryPosition;
    private bool isEmpty = true;
    private Transform itemInInventory;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Already a InventoryManager in scene destroying: " + gameObject);
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public bool GetIsEmpty()
    {
        return isEmpty;
    }

    public void AddItemToInventory(Transform item)
    {

        Debug.Log("added");
        if (!isEmpty) return;

        item.GetComponent<Collider>().enabled = false;
        if (item.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.useGravity = false;
            rb.mass = 0;
        }
        item.parent = player;
        item.transform.position = inventoryPosition.position;

        itemInInventory = item;
        isEmpty = false;
    }
    public void RemoveItemFromInventory()
    {
        itemInInventory.parent = null;
        itemInInventory.GetComponent<Collider>().enabled = true;
        if (itemInInventory.TryGetComponent<Rigidbody>(out Rigidbody rb)) rb.WakeUp();
        itemInInventory = null;
        isEmpty = true;
    }
    public Transform GetItemInInventory()
    {
        return itemInInventory;
    }
}
