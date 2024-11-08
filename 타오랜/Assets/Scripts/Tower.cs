using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private float attack = 10f;//공격력
    [SerializeField]
    private float attackrate = 1f;//공격속도
    [SerializeField]
    private float range = 2.5f;//공격 범위
    [SerializeField]

    private Transform target;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("FindTarget", 0f, 0.5f);
        InvokeRepeating("Attack", 0f, 1f / attackrate);
    }
    private void Attack()
    {
        if (target != null)
        {
            Enemy enemy = target.GetComponent<enemy>;
            if (enemy != null)
            {
                enemy.Takedamage(attack);
            }
        }


    }
    private void FindTarget()
    {
        // 범위 내의 모든 적 탐색
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, range);

        // 가장 가까운 적 찾기
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider2D collider in enemiesInRange)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, collider.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = collider.transform;
                }
            }
        }

        // 타겟 설정
        target = closestEnemy;

    }
}
