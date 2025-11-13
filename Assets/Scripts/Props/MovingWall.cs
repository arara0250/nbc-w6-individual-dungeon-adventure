using System.Collections;
using UnityEngine;

public class MovingWall : MonoBehaviour, IDamagable
{
    [Header("Trap Settings")]
    public Transform targetPosition;  // 벽이 이동할 목표 위치 (중앙 등)
    public float moveSpeed = 2f;      // 이동 속도
    public float waitTime = 2f;       // 방향 전환 전 대기 시간
    public bool moveOnStart = true;   // 시작하자마자 이동 여부

    private Vector3 startPos;
    private Vector3 endPos;
    private bool isMoving = false;
    private bool movingToCenter = true;

    void Start()
    {
        startPos = transform.position;

        if (targetPosition != null)
            endPos = targetPosition.position;

        if (moveOnStart)
            StartMoving();
    }

    void Update()
    {
        if (!isMoving) return;

        Vector3 target = movingToCenter ? endPos : startPos;

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        // 목표 지점 도달 시
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            transform.position = target;
            isMoving = false;
            StartCoroutine(SwitchDirectionAfterDelay());
        }
    }

    // 벽 이동 시작
    public void StartMoving()
    {
        if (targetPosition == null)
        {
            Debug.LogWarning($"{name}의 targetPosition이 설정되지 않았습니다!");
            return;
        }

        isMoving = true;
        movingToCenter = true;
    }

    // 일정 시간 기다린 후 방향 전환
    private IEnumerator SwitchDirectionAfterDelay()
    {
        yield return new WaitForSeconds(waitTime);
        movingToCenter = !movingToCenter;  // 방향 반전
        isMoving = true;
    }

    public IEnumerator GiveDamage(GameObject other)
    {
        throw new System.NotImplementedException();
    }
}
