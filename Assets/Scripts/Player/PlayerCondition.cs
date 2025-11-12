using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    private Hearts hearts { get { return GameManager.Instance.UIManager.hearts; } }

    void Update()
    {
        // 디버깅용
        if (Input.GetKeyDown(KeyCode.Alpha1))
            TakeDamage();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            Heal();
    }

    void TakeDamage()
    {
        hearts.TakeDamage();
    }

    void Heal()
    {
        hearts.Heal();
    }
}
