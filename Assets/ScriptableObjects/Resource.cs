using UnityEngine;

[CreateAssetMenu(fileName = "New Resource", menuName = "Game/Resource Data")]
public class Resource : ScriptableObject
{
    public string itemName;
    public Vector3 offset;

}
