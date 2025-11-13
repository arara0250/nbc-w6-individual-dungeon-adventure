using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        GameManager.Instance.PlayerManager.animationHandler = this;
    }

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void OnWalkingAnim()
    {
        _animator.SetBool("IsMoving", true);
    }

    public void OffWalkingAnim() 
    {
        _animator.SetBool("IsMoving", false);
    }

    public void OnJumpAnim()
    {
        _animator.SetTrigger("Jump");
    }

    public void OnInteractionAnim()
    {
        _animator.SetTrigger("Interact");
    }

    public void OnHitAnim()
    {
        _animator.SetTrigger("Damaged");
    }
}
