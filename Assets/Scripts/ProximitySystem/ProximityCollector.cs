using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProximityCollector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float collectionRadius = 5f;

    public Transform inventoryRoot;
    private Inventory inventory;

    private float slotSpacing = 0.2f;

    void Start()
    {
        GetComponent<SphereCollider>().radius = collectionRadius;
        inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if(item)
        {
            Debug.Log(item.name);
            Transform slot = new GameObject("InventorySlot").transform;

            slot.SetParent(inventoryRoot);

            slot.localPosition = new Vector3(0, slotSpacing * inventory.itemCount, 0);
            Debug.Log(slot.localPosition);
            slot.localRotation = Quaternion.identity;

            item.inventoryPos = slot;

            inventory.addItem(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
