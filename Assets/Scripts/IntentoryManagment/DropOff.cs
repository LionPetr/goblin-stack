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
        if (playerDropping && playerInventory.resourceCount > 0)
        {
            timer += Time.deltaTime;

            if (timer > dropOffSpeed)
            {
                Resource resource = playerInventory.GetFirstResource();
                if (dropOffInventory.addResource(resource))
                {
                    playerInventory.removeResource();
                }
                timer = 0f;
            }
        }
    }


}
