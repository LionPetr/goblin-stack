using Mono.Cecil;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/*
 * Proximity collector designed to transfer items to the inventory and keep track of
 * items that can be collected around it
 * - constantly keeps track of items close enough to be collected
 * - if the inventory component allows it the proximity collector sends it items
 *   ready to be picked up. 
 * last update: 1/5/2026
 */
public class ProximityCollector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float collectionRadius = 3.2f;

    private Inventory inventory;

    private List<Resource> collectableResources = new List<Resource>();

    void Start()
    {
        GetComponent<SphereCollider>().radius = collectionRadius;
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        for (int i = 0; i < collectableResources.Count; i++)
        {
            if (inventory.addResource(collectableResources[i]))
            {
                collectableResources[i].GetComponent<BoxCollider>().enabled = false;
                collectableResources.Remove(collectableResources[i]);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Resource resource = other.GetComponent<Resource>();
        if(resource)
        {
            collectableResources.Add(resource);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Resource resource = other.GetComponent<Resource>();
        if (resource)
        {
            collectableResources.Remove(resource);
        }
    }


}
