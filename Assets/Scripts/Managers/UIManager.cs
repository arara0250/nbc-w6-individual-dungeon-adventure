using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Hearts hearts;
    public Inventory inventory;

    private void Awake()
    {
        GameManager.Instance.UIManager = this;
    }
}
