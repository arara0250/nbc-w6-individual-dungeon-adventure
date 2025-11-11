using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerController controller;

    private void Awake()
    {
        GameManager.Instance.PlayerManager = this;
    }
}
