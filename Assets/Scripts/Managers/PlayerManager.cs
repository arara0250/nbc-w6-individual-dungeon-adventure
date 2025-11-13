using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    public PlayerAnimationHandler animationHandler;

    public ItemData curInteractItem;
    public Action addItem;

    private void Awake()
    {
        GameManager.Instance.PlayerManager = this;
    }
}
