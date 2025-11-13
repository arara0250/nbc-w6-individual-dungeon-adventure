using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public GameObject itemPrefab;

    [Header("Potion")]
    public float duration;
}
