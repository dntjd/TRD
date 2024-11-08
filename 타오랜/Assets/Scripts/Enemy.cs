using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f; // 적의 체력
    public float speed = 2f; // 이동 속도
    private Transform[] path; // 이동할 경로
    private int currentPathIndex = 0;

    // 경로 설정
    public void SetPath(Transform[] path)
    {
        this.path = path;
        transform.position = path[0].position;
    }

    void Update()
    {
        MoveAlongPath();
    }

    // 경로를 따라 이동
    private void MoveAlongPath()
    {
        if (currentPathIndex < path.Length)
        {
            Vector3 targetPosition = path[currentPathIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentPathIndex++;
            }
        }
        else
        {
            ReachEnd();
        }
    }

    // 경로 마지막에 도착했을 때 처리
    private void ReachEnd()
    {
        Destroy(gameObject); // 여기서는 단순히 파괴하지만, 도착 시 플레이어에게 피해를 줄 수도 있음.
    }

    // 피해를 입는 메서드
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // 적이 죽었을 때 처리
    private void Die()
    {
        Destroy(gameObject);
        // 적이 죽을 때 보상 처리 등을 추가 가능
    }
}
