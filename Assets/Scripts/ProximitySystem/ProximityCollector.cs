using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProximityCollector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float pullSpeed = 10f;
    public float collectionRadius = 5f;
    private List<Rigidbody> items = new List<Rigidbody>();

    public Transform stackOffsetPos;
    //private Vector3 stackPositionOffset = new Vector3(0, 0, 0.7f);
    private Inventory inventory;

    void Start()
    {
        GetComponent<SphereCollider>().radius = collectionRadius;
        inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item"))
        {
            items.Add(other.attachedRigidbody);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            items.Remove(other.attachedRigidbody);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = items.Count - 1; i >= 0; i--)
        {
            Rigidbody item = items[i];
            //Debug.Log(Vector3.Distance(stackOffsetPos.position, item.transform.position));
            if(Vector3.Distance(stackOffsetPos.position, item.transform.position) < 0.4f)
            {
                item.linearVelocity = Vector3.zero;
                item.angularVelocity = Vector3.zero;
                item.isKinematic = true;
                items.Remove(item);

                if(inventory)
                {
                    inventory.addItem(item);
                }
            }
            else
            {
                Vector3 dir = (transform.position - item.transform.position).normalized;
                item.AddForce(dir * pullSpeed, ForceMode.Acceleration);
            }
                
        }
    }
}
