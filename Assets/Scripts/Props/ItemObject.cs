using UnityEngine;

public interface IInteractable
{
    public string GetInteractionText();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;
    
    public string GetInteractionText()
    {
        return $"{data.itemName} ( E : 줍기 )";
    }

    public void OnInteract()
    {
        GameManager.Instance.PlayerManager.curInteractItem = data;
        GameManager.Instance.PlayerManager.addItem?.Invoke();
        Destroy(gameObject);
    }
}
