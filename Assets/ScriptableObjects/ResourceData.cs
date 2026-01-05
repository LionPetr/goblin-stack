using UnityEngine;

/*
 * ResourceData contains all the data about the resource 
 * - includes resource name to identify the resource
 * - includes the offset used in the inventory (unused currently)
 * last update: 1/5/2026
 */

[CreateAssetMenu(fileName = "New Resource", menuName = "Game/Resource Data")]
public class ResourceData : ScriptableObject
{
    public string resourceName;
    public Vector3 offset;

}
