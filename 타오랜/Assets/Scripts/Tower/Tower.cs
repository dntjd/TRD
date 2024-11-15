using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private int attack = 10;//공격력
    [SerializeField]
    private float attackrate = 1f;//공격속도
    [SerializeField]
    private float range = 2.5f;//공격 범위
    [SerializeField]
    private Transform target;

    private int powerUpModuleCount = 0; // 적용된 공격력 모듈 개수
    private int attackSpeedUpModuleCount = 0; // 적용된 공격속도 모듈 개수
    private const int maxPowerUpModules = 4; // 공격력 모듈 최대 개수
    private const int maxAttackSpeedUpModules = 4; // 공격속도 모듈 최대 개수

    // Start is called before the first frame update
    private void Start()//게임 실행 시 적 감지, 공격 준비
    {
        InvokeRepeating("FindTarget", 0f, 0.5f);
        InvokeRepeating("Attack", 0f, 1f / attackrate);
    }
    private void Attack()//타워의 공격
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
        Collider2D[] RangeEnemy = Physics2D.OverlapCircleAll(transform.position, range);

        // 가장 가까운 적 찾기
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider2D collider in RangeEnemy)
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


    public bool CanApplyPowerUpModule()
    {
        return powerUpModuleCount < maxPowerUpModules;
    }

    public bool CanApplyAttackSpeedUpModule()
    {
        return attackSpeedUpModuleCount < maxAttackSpeedUpModules;
    }

    public void ApplyPowerUpModule()
    {
        if (CanApplyPowerUpModule())
        {
            attack += 5;
            powerUpModuleCount++;
        }
        else
        {
            Debug.LogWarning("공격력 모듈 적용 한도를 초과했습니다!");
        }
    }

    public void ApplyAttackSpeedUpModule()
    {
        if (CanApplyAttackSpeedUpModule())
        {
            attackrate *= 1.2f;
            CancelInvoke("Attack");
            InvokeRepeating("Attack", 0f, 1f / attackrate);
            attackSpeedUpModuleCount++;
        }
        else
        {
            Debug.LogWarning("공격속도 모듈 적용 한도를 초과했습니다!");
        }
    }
}



