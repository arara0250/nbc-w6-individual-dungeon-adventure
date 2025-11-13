using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    private Hearts hearts { get { return GameManager.Instance.UIManager.hearts; } }
    private Inventory inventory { get { return GameManager.Instance.UIManager.inventory; } }

    private void Awake()
    {
        GameManager.Instance.PlayerManager.condition = this;
    }

    void Update()
    {
        // 디버깅용
        if (Input.GetKeyDown(KeyCode.Minus))
            TakeDamage();

        if (Input.GetKeyDown(KeyCode.Equals))
            Heal();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            UseKey();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            UsePotion();

    }

    public void TakeDamage()
    {
        hearts.TakeDamage();
    }

    void Heal()
    {
        hearts.Heal();
    }

    void UseKey()
    {
        inventory.UseKey();
    }

    void UsePotion()
    {
        inventory.UseSpeedPotion();
    }
}
