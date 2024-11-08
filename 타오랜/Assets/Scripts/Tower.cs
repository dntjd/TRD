using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float health = 100f; // 타워 체력
    public float attackPower = 10f; // 타워 공격력
    public float attackRange = 5f; // 공격 범위
    public float attackInterval = 1f; // 공격 간격
    private float attackTimer;

    private Transform targetEnemy;

    // 업그레이드 관련 변수
    public float upgradedAttackPower = attackPower + 5f; // 업그레이드 후 공격력
    public float upgradedAttackRange = 7f; // 업그레이드 후 공격 범위
    public float upgradedAttackInterval = attackInterval * 0.8f; // 업그레이드 후 공격 간격

    public void Upgrade()
    {
        attackPower = upgradedAttackPower;
        attackRange = upgradedAttackRange;
        attackInterval = upgradedAttackInterval;
        Debug.Log("타워가 업그레이드되었습니다!");
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;

        if (targetEnemy == null || Vector3.Distance(transform.position, targetEnemy.position) > attackRange)
        {
            FindNewTarget();
        }

        if (targetEnemy != null && attackTimer <= 0)
        {
            Attack();
            attackTimer = attackInterval;
        }
    }

    // 주변 적 탐색
    void FindNewTarget()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
        float closestDistance = attackRange;

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    targetEnemy = collider.transform;
                    closestDistance = distance;
                }
            }
        }
    }

    // 타워가 적을 공격
    void Attack()
    {
        if (targetEnemy != null)
        {
            Enemy enemyScript = targetEnemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(attackPower);
            }
        }
    }

    void Die()
    {
        Destroy(gameObject); // 타워 파괴
    }
}
