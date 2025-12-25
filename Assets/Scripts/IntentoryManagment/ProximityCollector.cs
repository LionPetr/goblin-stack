using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ProximityCollector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float collectionRadius = 3.2f;

    private Inventory inventory;

    private List<Item> collectableItems = new List<Item>();

    void Start()
    {
        GetComponent<SphereCollider>().radius = collectionRadius;
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        for (int i = 0; i < collectableItems.Count; i++)
        {
            if (inventory.addItem(collectableItems[i]))
            {
                collectableItems[i].GetComponent<BoxCollider>().enabled = false;
                collectableItems.Remove(collectableItems[i]);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if(item)
        {
            collectableItems.Add(item);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item)
        {
            collectableItems.Remove(item);
        }
    }


}
