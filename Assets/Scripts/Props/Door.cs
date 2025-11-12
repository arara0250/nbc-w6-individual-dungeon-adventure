using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public string GetInteractionText()
    {
        return "열기[E]";
    }

    public void OnInteract()
    {
        _animator.SetTrigger("Open");
    }
}
