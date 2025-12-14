using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items = new List<Item>();

    public int itemCount = 0;
    public int inventorySize = 5;
    public Transform inventoryPosition;
    public Vector3 itemOffset = new Vector3 (0, 0.2f, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = items.Count - 1; i >= 0; i--)
        {
            if (!items[i].traveling)
            {
                items[i].transform.position = inventoryPosition.position + (i * items[0].resourceData.offset);
                items[i].transform.rotation = inventoryPosition.rotation;
            }
        }   
    }

    public bool addItem(Item item)
    {
        if (items.Count < inventorySize && (items.Count == 0 || items[0].resourceData.name == item.resourceData.name))
        {
            items.Add(item);

            item.inventorySlot.transform.SetParent(inventoryPosition);

            item.inventorySlot.transform.localPosition = item.resourceData.offset * itemCount;
            item.inventorySlot.transform.localRotation = Quaternion.identity;
            item.traveling = true;

            itemCount++;
            return true;
        }
        return false;
    }
}
