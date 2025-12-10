using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Rigidbody> items = new List<Rigidbody>();

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
            items[i].transform.position = inventoryPosition.position + (i * itemOffset);
            items[i].transform.rotation = inventoryPosition.rotation;
        }
    }

    public void addItem(Rigidbody item)
    {
        items.Add(item);
    }
}
