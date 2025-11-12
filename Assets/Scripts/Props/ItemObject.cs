using UnityEngine;

public interface IInteractable
{
    public string GetInteractionText();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public string GetInteractionText()
    {
        return "줍기 [E]";
    }

    public void OnInteract()
    {

    }
}
