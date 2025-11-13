using System.Collections;
using UnityEngine;

public interface IDamagable
{
    public IEnumerator GiveDamage(GameObject other);
}

public class Spike : MonoBehaviour, IDamagable
{
    private PlayerAnimationHandler _handler { get { return GameManager.Instance.PlayerManager.animationHandler; } }
    private PlayerCondition _condition { get { return GameManager.Instance.PlayerManager.condition; } }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("GiveDamage", collision.gameObject);
        }
    }

    public IEnumerator GiveDamage(GameObject other)
    {
        // 애니메이션 켜주고
        _handler.OnHitAnim();

        // 데미지 주고
        _condition.TakeDamage();

        yield return new WaitForSeconds(1f);

        // 리스폰
        Transform respawnPoint = transform.Find("RespawnPoint");
        other.transform.position = respawnPoint.position;
    }
}
