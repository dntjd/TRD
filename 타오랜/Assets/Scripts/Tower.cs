using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float health = 100f; // Ÿ�� ü��
    public float attackPower = 10f; // Ÿ�� ���ݷ�
    public float attackRange = 5f; // ���� ����
    public float attackInterval = 1f; // ���� ����
    private float attackTimer;

    private Transform targetEnemy;

    // ���׷��̵� ���� ����
    public float upgradedAttackPower = attackPower + 5f; // ���׷��̵� �� ���ݷ�
    public float upgradedAttackRange = 7f; // ���׷��̵� �� ���� ����
    public float upgradedAttackInterval = attackInterval * 0.8f; // ���׷��̵� �� ���� ����

    public void Upgrade()
    {
        attackPower = upgradedAttackPower;
        attackRange = upgradedAttackRange;
        attackInterval = upgradedAttackInterval;
        Debug.Log("Ÿ���� ���׷��̵�Ǿ����ϴ�!");
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

    // �ֺ� �� Ž��
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

    // Ÿ���� ���� ����
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
        Destroy(gameObject); // Ÿ�� �ı�
    }
}
