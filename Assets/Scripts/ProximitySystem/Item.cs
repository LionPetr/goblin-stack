using JetBrains.Annotations;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Transform inventoryPos;
    public float travelTime = 4f;
    public float arcHeight = 1.0f;

    public float t;

    public Resource resourceData;
    public bool inInventory = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!inInventory && inventoryPos)
        {
            TravelToInventory();
        }
    }

    void TravelToInventory()
    {
        t += Time.deltaTime / travelTime;
        t = Mathf.Clamp01(t);

        Vector3 start = transform.position;
        Vector3 end = inventoryPos.position;

        Vector3 linearPos = Vector3.Lerp(start, end, t);

        float height = arcHeight * 4f * (t - t * t);  // Parabola

        Vector3 finalPos = linearPos + Vector3.up * height;
        transform.position = finalPos;
        transform.rotation = Quaternion.Slerp(transform.rotation, inventoryPos.rotation, Time.deltaTime * 5f);

        if (t >= 1f)
            inInventory = true;
    }


}
