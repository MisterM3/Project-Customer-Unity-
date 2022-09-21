using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [SerializeField] Transform player;
    [SerializeField] Transform inventoryPosition;
    [SerializeField] float releaseDistance = 1;
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

    public bool IsEmpty()
    {
        return isEmpty;
    }

    public void AddItemToInventory(Transform item)
    {

        Debug.Log("added");
        if (!isEmpty) return;

        item.GetComponent<Collider>().enabled = false;
        //item.transform.LookAt(transform.forward);
        item.parent = player;
        item.transform.position = inventoryPosition.position;

        itemInInventory = item;
        itemInInventory.transform.rotation = player.rotation;
        isEmpty = false;
    }
    private void Update()
    {
        if (!IsEmpty() && Input.GetKeyDown(KeyCode.T))
        {
            itemInInventory.transform.rotation = player.rotation;
            //itemInInventory.LookAt(Vector3.back);
        }
    }
    public void RemoveItemFromInventory()
    {
        if (MouseWorld.Instance.GetObjectInFront(releaseDistance, out RaycastHit hit))
        {
            if (hit.normal == Vector3.up)
            {
                
                ResetObject(hit);
            }
        }
        else
        {
            RaycastHit groundHit;
            groundHit = MouseWorld.Instance.GetObjectInDirection(player.position, Vector3.down);
            ResetObject(groundHit);
        }
    }

    public void DestroyItemFromInventory()
    {
        Destroy(itemInInventory.gameObject);
        isEmpty = true;
    }

    public Transform GetItemInInventory()
    {
        return itemInInventory;
    }
    void ResetObject(RaycastHit hit)
    {
        var r = FindRenderer(itemInInventory);
        if (r == null) return;

        Vector3 dropPoint = new Vector3(hit.point.x, hit.point.y + r.localBounds.max.y, hit.point.z);
        itemInInventory.position = dropPoint;
        itemInInventory.rotation = Quaternion.identity;

        itemInInventory.parent = null;
        itemInInventory.GetComponent<Collider>().enabled = true;
        isEmpty = true;
        itemInInventory = null;
    }
    Renderer FindRenderer(Transform obj)
    {
        if(obj.TryGetComponent<Renderer>(out Renderer renderer))
        {
            return renderer;
        }
        renderer = obj.GetComponentInChildren<Renderer>();
        if (renderer != null) return renderer;
        return null;
    }
}
