using UnityEngine;

public class Hearts : MonoBehaviour
{
    [Header("Heart")]
    [SerializeField] private int curHearts;
    [SerializeField] private int maxHearts;

    private void Awake()
    {
        GameManager.Instance.UIManager.hearts = this;
    }

    private void Start()
    {
        curHearts = maxHearts;
    }

    public void TakeDamage()
    {
        transform.GetChild(curHearts - 1).gameObject.SetActive(false);
        curHearts--;
    }

    public void Heal()
    {
        transform.GetChild(curHearts).gameObject.SetActive(true);
        curHearts++;
    }
}
