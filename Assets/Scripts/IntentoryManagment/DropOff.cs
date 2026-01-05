using UnityEngine;

public class DropOff : MonoBehaviour
{
    public Inventory dropOffInventory;
    public bool playerDropping = false;

    public Inventory playerInventory;


    public float dropOffSpeed = 1.0f;
    private float timer = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDropping)
        {
            timer += Time.deltaTime;

            if (timer > dropOffSpeed)
            {
                Resource resource = playerInventory.GetFirstItem();
                if (dropOffInventory.addItem(resource))
                {
                    playerInventory.removeItem(resource);
                }
                timer = 0f;
            }
        }
    }


}
