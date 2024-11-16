using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpecialModule;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private int baseAttack = 10; // 기본 공격력
    [SerializeField]
    private float baseAttackRate = 1f; // 기본 공격속도
    [SerializeField]
    private float range = 2.5f; // 공격 범위
    [SerializeField]
    private Transform target;

    private int powerUpModuleCount = 0; // 공격력 모듈 개수
    private int attackSpeedUpModuleCount = 0; // 공격속도 모듈 개수
    private const int maxPowerUpModules = 4; // 공격력 모듈 최대 개수
    private const int maxAttackSpeedUpModules = 4; // 공격속도 모듈 최대 개수

    private SpecialModule currentSpecialModule; // 현재 적용된 특수 모듈
    private int specialModuleCount = 0; // 동일 특수 모듈 적용 횟수
    private const int maxSpecialModules = 4; // 동일 특수 모듈 최대 개수

    private void Start()
    {
        InvokeRepeating("FindTarget", 0f, 0.5f);
        InvokeRepeating("Attack", 0f, 1f / baseAttackRate);
    }

    private void Attack()
    {
        if (target != null)
        {
            if (currentSpecialModule != null)
            {
                // 특수 모듈 효과 호출
                currentSpecialModule.ApplyEffect(target, baseAttack);
            }
            else
            {
                // 일반 공격
                Enemy enemy = target.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(baseAttack);
                }
            }
        }
    }

    private void FindTarget()
    {
        Collider2D[] rangeEnemies = Physics2D.OverlapCircleAll(transform.position, range);

        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider2D collider in rangeEnemies)
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

        target = closestEnemy;
    }

    ppublic void ApplySpecialModule(SpecialModule specialModule)
    {
        if (currentSpecialModule != null)
        {
            // 이미 특수 모듈이 활성화된 경우
            if (currentSpecialModule.ModuleType == specialModule.ModuleType)
            {
                // 동일한 특수 모듈만 적용 가능
                if (specialModuleCount <= maxSpecialModules)
                {
                    currentSpecialModule.UpgradeModule();
                    specialModuleCount++;
                }
                else
                {
                    Debug.LogWarning("동일한 특수 모듈의 최대 적용 한도를 초과했습니다!");
                }
            }
            else
            {
                Debug.LogWarning("다른 종류의 특수 모듈은 적용할 수 없습니다!");
            }
        }
        else
        {
            // 기존 일반 모듈을 모두 제거
            ResetModules();

            // 특수 모듈 처음 적용
            currentSpecialModule = specialModule;
            specialModuleCount = 1;

            // 각 특수 포탑에 맞는 기본 스탯 설정
            switch (specialModule.ModuleType)
            {
                case SpecialModuleType.Penetrating:
                    baseAttack = 50;
                    baseAttackRate = 10f; // 10/s
                    break;

                case SpecialModuleType.Slow:
                    baseAttack = 10;
                    baseAttackRate = 1f; // 1/s
                    break;

                case SpecialModuleType.AoE:
                    baseAttack = 10;
                    baseAttackRate = 1f / 15f; // 1/15s
                    break;
            }

            // 특수 모듈의 공격 로직 활성화
            CancelInvoke("Attack");
            InvokeRepeating("Attack", 0f, 1f / baseAttackRate);
        }
    }

    // 공격력 모듈 적용
    public void ApplyPowerUpModule(int attackBoost)
    {
        if (currentSpecialModule != null)
        {
            Debug.LogWarning("특수 모듈이 활성화된 경우 일반 모듈을 적용할 수 없습니다!");
            return;
        }

        if (powerUpModuleCount <= maxPowerUpModules)
        {
            baseAttack += attackBoost;
            powerUpModuleCount++;
            Debug.Log("공격력 모듈 적용: " + attackBoost);
        }
        else
        {
            Debug.LogWarning("공격력 모듈의 최대 적용 한도를 초과했습니다!");
        }
    }

    // 공격속도 모듈 적용
    public void ApplyAttackSpeedUpModule(float attackRateBoost)
    {
        if (currentSpecialModule != null)
        {
            Debug.LogWarning("특수 모듈이 활성화된 경우 일반 모듈을 적용할 수 없습니다!");
            return;
        }

        if (attackSpeedUpModuleCount <= maxAttackSpeedUpModules)
        {
            baseAttackRate += attackRateBoost;
            attackSpeedUpModuleCount++;
            Debug.Log("공격속도 모듈 적용: " + attackRateBoost);
        }
        else
        {
            Debug.LogWarning("공격속도 모듈의 최대 적용 한도를 초과했습니다!");
        }

        // 공격속도 적용 반영
        CancelInvoke("Attack");
        InvokeRepeating("Attack", 0f, 1f / baseAttackRate);
    }

    // 모듈 적용 가능 여부 확인
    public bool CanApplyPowerUpModule()
    {
        return currentSpecialModule == null && powerUpModuleCount < maxPowerUpModules;
    }

    public bool CanApplyAttackSpeedUpModule()
    {
        return currentSpecialModule == null && attackSpeedUpModuleCount < maxAttackSpeedUpModules;
    }

    public void ResetModules()
    {
        baseAttack = 10;
        baseAttackRate = 1f;
        powerUpModuleCount = 0;
        attackSpeedUpModuleCount = 0;
        currentSpecialModule = null;
        specialModuleCount = 0;
        Debug.Log("모든 모듈이 초기화되었습니다.");
    }
}