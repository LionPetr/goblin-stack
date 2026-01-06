using Mono.Cecil;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

/*
 * Inventory Component designed to store resources 
 * - Manages Resource addition 
 * - Keeps track of where the next resource should go
 * 
 * This is meant to be used in addition to other components like ProximityCollector or 
 * different processing machines as their inventory
 * last update: 1/5/2026
 */
public class Inventory : MonoBehaviour
{
    private List<Resource> resources = new List<Resource>();

    public int resourceCount = 0;
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
        for (int i = resources.Count - 1; i >= 0; i--)
        {
            if (!resources[i].traveling)
            {
                resources[i].transform.position = inventoryPosition.position + (i * resources[0].resourceData.offset);
                resources[i].transform.rotation = inventoryPosition.rotation;
            }
        }   
    }

    public bool addItem(Resource resource)
    {
        Debug.Log("trying to add an item");
        if (resources.Count < inventorySize && (resources.Count == 0 || resources[0].resourceData.name == resource.resourceData.name))
        {
            resources.Add(resource);

            resource.inventorySlot.transform.SetParent(inventoryPosition);

            resource.inventorySlot.transform.localPosition = resource.resourceData.offset * resourceCount;
            resource.inventorySlot.transform.localRotation = Quaternion.identity;
            resource.startTravel();

            resourceCount++;
            return true;
        }
        return false;
    }


    public void removeItem(Resource resource)
    {
        if (resources.Count != 0)
        {
            resources.RemoveAt(resources.Count - 1);
            resourceCount--;
        }
    }

    public bool itemCanBeAdded(Resource resource)
    {
        return (resource != null && 
                resources.Count < inventorySize && 
                (resources.Count == 0 || resources[0].resourceData.name == resource.resourceData.name));
    }

    public Resource GetFirstItem()
    {
        if (resources.Count == 0)
        {
            return null;
        }
        return resources[resources.Count - 1];
    }
}


