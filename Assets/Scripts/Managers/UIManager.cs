using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Hearts hearts;

    private void Awake()
    {
        GameManager.Instance.UIManager = this;
    }
}
