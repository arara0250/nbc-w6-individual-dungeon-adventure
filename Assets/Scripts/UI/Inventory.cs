using System.Collections;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private TextMeshProUGUI keyCountText;
    [SerializeField] private TextMeshProUGUI potionCountText;
    public int keyCount = 0;
    public int potionCount = 0;

    private void Awake()
    {
        GameManager.Instance.UIManager.inventory = this;
    }

    private void Start()
    {
        GameManager.Instance.PlayerManager.addItem += AddItem;
    }

    void AddItem()
    {
        ItemData curItem = GameManager.Instance.PlayerManager.curInteractItem;

        switch (curItem.name)
        {
            case "Item_Key":
                keyCount++;
                break;
            case "Item_SpeedPotion":
                potionCount++;
                break;
            default:
                break;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        keyCountText.text = keyCount.ToString();
        potionCountText.text = potionCount.ToString();
    }

    public void UseKey()
    {
        if (keyCount <= 0) return;

        keyCount--;
        UpdateUI();
    }

    public void UseSpeedPotion()
    {
        if (potionCount <= 0) return;

        potionCount--;
        UpdateUI();

        StartCoroutine(SpeedUpCoroutine());
    }

    IEnumerator SpeedUpCoroutine()
    {
        PlayerController controller = GameManager.Instance.PlayerManager.controller;
        
        float beforeSpeed = controller.GetMoveSpeed();

        controller.SetMoveSpeed(beforeSpeed * 2f);

        yield return new WaitForSeconds(3.0f);

        controller.SetMoveSpeed(beforeSpeed);
    }
}
