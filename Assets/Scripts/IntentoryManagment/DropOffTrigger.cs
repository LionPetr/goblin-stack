using UnityEngine;

public class DropOffTrigger : MonoBehaviour
{
    public DropOff dropoff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dropoff.playerDropping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dropoff.playerDropping = false;
        }
    }
}
